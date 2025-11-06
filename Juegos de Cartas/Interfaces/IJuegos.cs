using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IJuegos<TCarta> where TCarta : ICarta <int>
{
  public void IniciarJuego();
  public void TomarDecision();
  public void SiguienteJugador();
  public bool SePuedeJugar();
  public void MovimientoDeCartas();
}
