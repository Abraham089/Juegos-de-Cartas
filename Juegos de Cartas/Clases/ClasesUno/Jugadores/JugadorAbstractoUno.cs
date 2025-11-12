using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases;

namespace Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

public abstract class JugadorAbstractoUno : IJugadores<CartaUnoAbstracta>
{
  // El nombre debe ser provisto por la implementación concreta
  public abstract string Nombre { get; }

  // Proveemos una mano por defecto para simplificar implementaciones concretas
  private readonly Mano<CartaUnoAbstracta> _mano = new Mano<CartaUnoAbstracta>();
  public virtual IMano<CartaUnoAbstracta> Mano => _mano;

  // Puntos acumulados por el jugador (implementación básica)
  public virtual int Puntos { get; protected set; }

  // Métodos que deben implementar los jugadores concretos
  public abstract CartaUnoAbstracta DecidirJugarCartaRobada(CartaUnoAbstracta cartaRobada, CartaUnoAbstracta cartaSuperior);

  public abstract CartaUnoAbstracta JugarCarta();

  // Comportamientos por defecto
  public virtual void NuevaMano()
  {
    Mano.Limpiar();
  }

  public virtual void RecibirCarta(CartaUnoAbstracta carta)
  {
    if (carta == null) throw new ArgumentNullException(nameof(carta));
    Mano.AgregarCarta(carta);
  }
}
