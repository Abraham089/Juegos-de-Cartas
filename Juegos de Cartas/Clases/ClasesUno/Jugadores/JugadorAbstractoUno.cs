using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

public abstract class JugadorAbstractoUno : IJugadores<CartaUnoAbstracta>
{
  public string Nombre => throw new NotImplementedException();

  public IMano<CartaUnoAbstracta> Mano => throw new NotImplementedException();

  public int Puntos => throw new NotImplementedException();

  public CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior)
  {
    throw new NotImplementedException();
  }

  public CartaUnoAbstracta JugarCarta()
  {
    throw new NotImplementedException();
  }

  public void NuevaMano()
  {
    throw new NotImplementedException();
  }

  public void RecibirCarta(CartaUnoAbstracta carta)
  {
    throw new NotImplementedException();
  }
}
