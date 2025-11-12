using System;
using Juegos_de_Cartas.Clases.ClasesUno;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

namespace Juegos_de_Cartas.Interfaces;

public interface IEfectoDeCarta
{
  public void Efecto(JuegoUno juego, JugadorAbstractoUno jugadorCausante);
}
