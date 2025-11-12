using System;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesUno.Efectos;

public class TomarCarta : Interfaces.IEfectoDeCarta
{
  private readonly int _cantidadARobar;

  public TomarCarta(int cantidad)
    {
      if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad a robar debe ser positiva.", nameof(cantidad));
        }
        _cantidadARobar = cantidad;
    }
  public void Efecto(JuegoUno juego, JugadorAbstractoUno jugadorCausante)
  {
    IJugadores<CartaUnoAbstracta> jugadorAfectado = juego.ObtenerSiguienteJugador();
        juego.ForzarRoboACantidad(jugadorAfectado, _cantidadARobar);
  }
}