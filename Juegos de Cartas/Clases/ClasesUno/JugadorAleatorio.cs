using System;
using System.Linq;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesUno;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

namespace Juegos_de_Cartas.Clases.ClasesUno;

// Jugador aleatorio para Uno: elige al azar una carta jugable de su mano.
public class JugadorAleatorio : JugadorAbstractoUno
{
    private readonly Random _rng = new Random();
    private readonly string _nombre;

    public JugadorAleatorio(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));
        _nombre = nombre;
    }

    // Nombre del jugador (implementación simple)
    public override string Nombre => _nombre;

    // El juego llama a JugarCarta() para pedir la carta que jugará en su turno
    public override CartaUnoAbstracta JugarCarta()
    {
        var mano = Mano;
        if (mano == null || mano.EstaVacio) return null!;

        // No conocemos la carta superior desde aquí; devolveremos una carta aleatoria de la mano.
        var cartas = mano.Cartas.ToList();
        int idx = _rng.Next(cartas.Count);
        var cartaSeleccionada = cartas[idx];
        // Remover la carta de la mano al jugarla
        mano.RemoverCarta(cartaSeleccionada);
        return cartaSeleccionada;
    }

    // Si el jugador roba una carta, decide si jugarla inmediatamente o quedarse con ella.
    // Aquí recibimos la carta robada y la carta superior para decidir si la jugamos.
    public override CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior)
    {
        if (cartaRobada == null) return null!;

        // Si la carta robada es jugable sobre la carta superior, el jugador la jugará con una probabilidad del 50%.
        if (JuegoUno.SePuedeJugar(cartaRobada, cartaSuperior))
        {
            // 50% de probabilidad de jugarla inmediatamente
            if (_rng.NextDouble() < 0.5)
            {
                return cartaRobada;
            }
        }

        // Si no la juega, la añade a su mano (el juego invoca RecibirCarta en el flujo normal)
        return null!;
    }
}
