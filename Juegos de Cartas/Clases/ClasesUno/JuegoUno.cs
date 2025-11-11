using System;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public class JuegoUno : JuegoMain<CartaUnoAbstracta>
{
  public CartaUnoAbstracta CartaEncima
  {
    get
    {
      if (CartasUsadas.Cartas.Count == 0)
      {

        throw new Exception("La pila de descarte está vacía. El juego debe inicializarse.");
      }
      return CartasUsadas.Cartas.Last();
    }
  }
  public JuegoUno(List<IJugadores<CartaUnoAbstracta>> jugadores, Deck<CartaUnoAbstracta> deck) : base(jugadores, deck)
  {
  }

  public override void HacerJugada()
  {
    var jugadorActual = (JugadorAbstractoUno)JugadorActual;
    CartaUnoAbstracta cartaSuperior = CartaEncima;

    CartaUnoAbstracta cartaElegida = jugadorActual.JugarCarta(); //jugadorActual.JugarCarta(cartaSuperior); 

    if (cartaElegida != null && SePuedeJugar(cartaElegida))
    {
        CartasUsadas.AgregarCarta(cartaElegida);
        AplicarEfectos(cartaElegida); 
        SiguienteJugador(); 
    }
    else
    {
        CartaUnoAbstracta cartaRobada = RobarCartaDelMazo(); 
        jugadorActual.RecibirCarta(cartaRobada); 

        CartaUnoAbstracta cartaJugable = jugadorActual.DecidirJugarCartaRobada(cartaRobada, cartaSuperior);

        if (cartaJugable != null)
        {
            CartasUsadas.AgregarCarta(cartaJugable);
            AplicarEfectos(cartaJugable);
        }
        
        SiguienteJugador();
    }
  }

  public override void IniciarJuego()
  {
    throw new NotImplementedException();
  }

  public override bool SePuedeJugar(CartaUnoAbstracta carta)
  {
    throw new NotImplementedException();
  }
  public void AplicarEfectos(CartaUnoAbstracta carta)
  {
    if(carta is CartaTrampa cartaTrampa)
    {
      foreach(IEfectoDeCarta efecto in cartaTrampa.Efectos)
      {
        efecto.Efecto(); //ver como se va a implementar el efecto, por ahora lo mas seguro es que reciba un juego y al jugador que lo hizo
      }
    }
  }
  public CartaUnoAbstracta RobarCartaDelMazo()
  {
    CartaUnoAbstracta cartaRobada = (CartaUnoAbstracta)Deck.TomarCarta();
    return cartaRobada;
  }
}

