using System;
using System.Linq;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesUno;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public class JugadorCalculador : JugadorAbstractoUno
{
  public JugadorCalculador(string nombre) : base(nombre)
  {
  }

  public override CartaUnoAbstracta JugarCarta(CartaUnoAbstracta cartaSuperior, IJugadores<CartaUnoAbstracta>? siguienteJugador = null)
    {
        var mano = Mano;
        if (mano == null || mano.EstaVacio)
        {
            return null; 
        }
            
        if (siguienteJugador != null && siguienteJugador.Mano.CantidadCartas == 1)
        {
            var mejorEspecial = EncontrarMejorCartaEspecial(cartaSuperior);
            if (mejorEspecial != null)
            {
                mano.RemoverCarta(mejorEspecial);
                return mejorEspecial;
            }
        }

        var cartaNormal = EncontrarCartaNormal(cartaSuperior);
        if (cartaNormal != null)
        {
            mano.RemoverCarta(cartaNormal);
            return cartaNormal;
        }

        var cualquierEspecial = EncontrarCualquierCartaEspecial(cartaSuperior);
        if (cualquierEspecial != null)
        {
            mano.RemoverCarta(cualquierEspecial);
            return cualquierEspecial;
        }
        
        return null;
    }

    public override CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior, IJugadores<CartaUnoAbstracta>? siguienteJugador)
    {
        if (cartaRobada == null) return null;

        if (cartaRobada is CartaTrampa && siguienteJugador != null && siguienteJugador.Mano.CantidadCartas == 1)
        {
            if (JuegoUno.SePuedeJugar(cartaRobada, cartaSuperior))
            {
                return cartaRobada; 
            }
        }
        
        if (cartaRobada is CartaNormal && JuegoUno.SePuedeJugar(cartaRobada, cartaSuperior))
        {
            return cartaRobada;
        }

        return null;
    }

    private CartaUnoAbstracta? EncontrarMejorCartaEspecial(CartaUnoAbstracta cartaSuperior)
    {
        
        var cartaValida = Mano.Cartas
            .OfType<CartaTrampa>()
            .Where(c => JuegoUno.SePuedeJugar(c, cartaSuperior)) 
            .FirstOrDefault();
            
        return cartaValida;
    }

    private bool TieneEfectoTomarCarta(CartaTrampa carta)
    {
        if (carta?.Efectos == null)
        {
            return false;
        }
        
        return carta.Efectos.Any(e => e.GetType().Name.Contains("TomarCarta") || 
                                       e.GetType().Name.Contains("Tomar"));
    }
    private CartaNormal? EncontrarCartaNormal(CartaUnoAbstracta cartaSuperior)
    {
        var mano = Mano;
        if (mano == null || mano.EstaVacio) return null;

        // Usamos LINQ para encontrar la primera CartaNormal que sea legal de jugar
        return mano.Cartas
            .OfType<CartaNormal>()
            // Aplicamos la regla estática de la Partida
            .FirstOrDefault(c => JuegoUno.SePuedeJugar(c, cartaSuperior));
    }
    private CartaTrampa? EncontrarCualquierCartaEspecial(CartaUnoAbstracta cartaSuperior)
{
    var mano = Mano;
    if (mano == null || mano.EstaVacio) return null;

    // Buscamos la primera CartaTrampa legal que se pueda jugar
    return mano.Cartas
        .OfType<CartaTrampa>()
        // Aplicamos la regla estática de la Partida
        .FirstOrDefault(c => JuegoUno.SePuedeJugar(c, cartaSuperior));
}
}
