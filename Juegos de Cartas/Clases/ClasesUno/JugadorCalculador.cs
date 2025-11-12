using System;
using System.Linq;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesUno;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

namespace Juegos_de_Cartas.Clases.ClasesUno;

/// <summary>
/// Jugador Calculador: Su objetivo es ganar a toda costa.
/// - Monitorea el número de cartas del siguiente jugador.
/// - Juega cartas normales siempre que sea posible.
/// - Si el siguiente jugador tiene solo 1 carta, lanza cartas especiales (priorizando las que hagan tomar cartas).
/// - Si no tiene cartas especiales y el oponente tiene 1 carta, roba esperando conseguir una especial.
/// </summary>
public class JugadorCalculador : JugadorAbstractoUno
{
    private readonly string _nombre;
    private readonly Func<IJugadores<CartaUnoAbstracta>> _obtenerSiguienteJugador;

    public JugadorCalculador(string nombre, Func<IJugadores<CartaUnoAbstracta>> obtenerSiguienteJugador)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));
        _nombre = nombre;
        _obtenerSiguienteJugador = obtenerSiguienteJugador ?? throw new ArgumentNullException(nameof(obtenerSiguienteJugador));
    }

    public override string Nombre => _nombre;

    public override CartaUnoAbstracta JugarCarta()
    {
        var mano = Mano;
        if (mano == null || mano.EstaVacio) return null!;

        var siguienteJugador = _obtenerSiguienteJugador();
        int cartasSiguiente = siguienteJugador?.Mano?.CantidadCartas ?? 0;

        // Si el siguiente jugador tiene solo 1 carta, intenta jugar una especial
        if (cartasSiguiente == 1)
        {
            var cartaEspecial = EncontrarMejorCartaEspecial();
            if (cartaEspecial != null)
            {
                mano.RemoverCarta(cartaEspecial);
                return cartaEspecial;
            }
        }

        // Si no hay especial (o el oponente tiene más cartas), intenta jugar una normal
        var cartaNormal = EncontrarCartaNormal();
        if (cartaNormal != null)
        {
            mano.RemoverCarta(cartaNormal);
            return cartaNormal;
        }

        // Si no hay cartas normales, juega cualquier carta disponible
        var cartaQualquier = mano.Cartas.FirstOrDefault();
        if (cartaQualquier != null)
        {
            mano.RemoverCarta(cartaQualquier);
        }
        return cartaQualquier!;
    }

    public override CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior)
    {
        if (cartaRobada == null) return null!;

        var siguienteJugador = _obtenerSiguienteJugador();
        int cartasSiguiente = siguienteJugador?.Mano?.CantidadCartas ?? 0;

        // Si el siguiente jugador tiene solo 1 carta
        if (cartasSiguiente == 1)
        {
            // Si la carta robada es especial y es jugable, la juega
            if (cartaRobada is CartaTrampa && JuegoUno.SePuedeJugar(cartaRobada, cartaSuperior))
            {
                return cartaRobada;
            }
        }

        // Si es una carta normal jugable, considera jugarla
        if (cartaRobada is CartaNormal && JuegoUno.SePuedeJugar(cartaRobada, cartaSuperior))
        {
            return cartaRobada;
        }

        // Si no es jugable o es especial pero el oponente tiene más de 1 carta, la guarda
        return null!;
    }

    /// <summary>
    /// Busca la mejor carta especial para jugar.
    /// Prioriza las cartas que hacen tomar cartas (TomarCarta) sobre otras especiales.
    /// </summary>
    private CartaTrampa? EncontrarMejorCartaEspecial()
    {
        var mano = Mano;
        if (mano == null || mano.EstaVacio) return null;

        var especialesTomar = mano.Cartas
            .OfType<CartaTrampa>()
            .Where(c => TieneEfectoTomarCarta(c))
            .FirstOrDefault();

        if (especialesTomar != null) return especialesTomar;

        // Si no hay especiales de tomar, devuelve cualquier especial
        return mano.Cartas.OfType<CartaTrampa>().FirstOrDefault();
    }

    /// <summary>
    /// Comprueba si una carta tiene algún efecto de tipo "TomarCarta".
    /// </summary>
    private bool TieneEfectoTomarCarta(CartaTrampa carta)
    {
        if (carta?.Efectos == null) return false;
        
        // Busca efectos cuyo tipo contenga "TomarCarta" o similar
        return carta.Efectos.Any(e => e.GetType().Name.Contains("TomarCarta") || 
                                       e.GetType().Name.Contains("Tomar"));
    }

    /// <summary>
    /// Busca una carta normal en la mano.
    /// </summary>
    private CartaNormal? EncontrarCartaNormal()
    {
        var mano = Mano;
        if (mano == null || mano.EstaVacio) return null;
        return mano.Cartas.OfType<CartaNormal>().FirstOrDefault();
    }
}
