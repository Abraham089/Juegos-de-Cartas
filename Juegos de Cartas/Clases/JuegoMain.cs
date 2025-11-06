using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases;

public abstract class JuegoMain<TCarta> where TCarta : class
{
  private List<IJugadores<TCarta>> _jugadores;
  public List<IJugadores<TCarta>> Jugadores
  {
    get { return _jugadores; }
    set { Jugadores = value; }
  }
  //public IJugadores<TCarta> JugadorActual;
  //Aun voy a pensar en la implementacion del jugador actual
  private Deck<TCarta> _deck;
  public Deck<TCarta> Deck
  {
    get { return _deck; }
    set { _deck = value; }
  }
  private Deck<TCarta> _cartasUsadas;
  public Deck<TCarta> CartasUsadas
  {
    get { return _cartasUsadas; }
    set { _cartasUsadas = value; }
  }
  protected int _sentido = 1;

  public JuegoMain(List<IJugadores<TCarta>> jugadores, Deck<TCarta> deck)
  {
    Jugadores = jugadores;
    Deck = deck;
  }
  public virtual void IniciarJuego()
  {
    throw new NotImplementedException();
  }
  public virtual void TomarDecision()
  {
    throw new NotImplementedException();
  }
  public virtual void SiguienteJugador()
  {
    throw new NotImplementedException();
  }
  public virtual bool SePuedeJugar()
  {
    throw new NotImplementedException();
  }
  public virtual void MovimientoDeCartas()
  {
    throw new NotImplementedException();
  }
}
