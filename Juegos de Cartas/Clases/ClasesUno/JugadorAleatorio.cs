using System;
using System.Linq;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesUno;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public class JugadorAleatorio : JugadorAbstractoUno
{
    private readonly Random _rng;

    public JugadorAleatorio(string nombre) : base(nombre)
  {
        _rng = new Random();
  }
  public override CartaUnoAbstracta JugarCarta(CartaUnoAbstracta cartaSuperior, IJugadores<CartaUnoAbstracta>? siguienteJugador)
    {
        return JugarCarta(cartaSuperior);
    }

  public CartaUnoAbstracta JugarCarta(CartaUnoAbstracta cartaSuperior)
{
    var mano = Mano;
    if (mano == null || mano.EstaVacio) return null!;

    var cartasLegales = mano.Cartas
        .Where(c => JuegoUno.SePuedeJugar(c, cartaSuperior))
        .ToList();
    if (!cartasLegales.Any())
    {
        return null!;
    }

    int idx = _rng.Next(cartasLegales.Count);
    var cartaSeleccionada = cartasLegales[idx];

    mano.RemoverCarta(cartaSeleccionada);
    return cartaSeleccionada;
}

    public override CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior, IJugadores<CartaUnoAbstracta>? siguienteJugador)
    {
        return DecidirJugarCartaRobada(cartaRobada, cartaSuperior);
    }
    public CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior)
    {
        if (cartaRobada == null) return null!;

        if (JuegoUno.SePuedeJugar(cartaRobada, cartaSuperior))
        {
            if (_rng.NextDouble() < 0.5)
            {
                return cartaRobada;
            }
        }

        return null!;
    }
}