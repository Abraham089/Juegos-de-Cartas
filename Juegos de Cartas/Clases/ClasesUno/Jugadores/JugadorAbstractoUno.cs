using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases;

namespace Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

public abstract class JugadorAbstractoUno : Jugadores<CartaUnoAbstracta>
{
  protected JugadorAbstractoUno(string nombre) : base(nombre)
  {
  }

public abstract CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior, IJugadores<CartaUnoAbstracta>? siguienteJugador);

  public abstract CartaUnoAbstracta JugarCarta(CartaUnoAbstracta cartaSuperior, IJugadores<CartaUnoAbstracta>? siguienteJugador);

  public virtual void RecibirCarta(CartaUnoAbstracta carta)
  {
    if (carta == null) throw new ArgumentNullException(nameof(carta));
    Mano.AgregarCarta(carta);
  }
}
