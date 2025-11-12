using System;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

namespace Juegos_de_Cartas.Clases.ClasesUno.Efectos;

public class SaltarTurno : Interfaces.IEfectoDeCarta
{
  public void Efecto(JuegoUno juego, JugadorAbstractoUno jugadorCausante)
  {
    juego.SaltarProximoTurno(1);
  }
}
