using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public class JuegoUno : JuegoMain<CartaUnoAbstracta>
{
  public JuegoUno(List<IJugadores<CartaUnoAbstracta>> jugadores, Deck<CartaUnoAbstracta> deck) : base(jugadores, deck)
  {
  }

  public override void HacerJugada()
  {
    throw new NotImplementedException();
  }

  public override void IniciarJuego()
  {
    throw new NotImplementedException();
  }

  public override bool SePuedeJugar(CartaUnoAbstracta carta)
  {
    throw new NotImplementedException();
  }
}

