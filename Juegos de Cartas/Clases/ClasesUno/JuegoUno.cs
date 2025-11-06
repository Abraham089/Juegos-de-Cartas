using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public class JuegoUno : JuegoMain<CartaUnoAbstracta>
{
  public JuegoUno(List<IJugadores<CartaUnoAbstracta>> jugadores, Deck<CartaUnoAbstracta> deck) : base(jugadores, deck)
  {
  }

  public void IniciarJuego()
  {
    throw new NotImplementedException();
  }

  public void MovimientoDeCartas()
  {
    throw new NotImplementedException();
  }

  public bool SePuedeJugar()
  {
    throw new NotImplementedException();
  }

  public void SiguienteJugador()
  {
    throw new NotImplementedException();
  }

  public void TomarDecision()
  {
    throw new NotImplementedException();
  }
}
