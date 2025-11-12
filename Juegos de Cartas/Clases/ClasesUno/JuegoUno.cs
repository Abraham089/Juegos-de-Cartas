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

    if (cartaElegida != null)
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
    Deck.Bareajear(); 
    
    RepartirCartas(7); 

    CartaUnoAbstracta primeraCarta = RobarCartaDelMazo();
    while (primeraCarta is CartaTrampa) 
    {
        primeraCarta = RobarCartaDelMazo(); 
    }
    CartasUsadas.AgregarCarta(primeraCarta);
  }

  private void RepartirCartas(int numCartas)
{
    for (int i = 0; i < numCartas; i++)
    {
        foreach (var jugador in Jugadores)
        {
            CartaUnoAbstracta carta = RobarCartaDelMazo();
            
            jugador.RecibirCarta(carta);
        }
    }
}
  public static bool SePuedeJugar(CartaUnoAbstracta cartaJugada, CartaUnoAbstracta cartaEncima)
  {
    if (cartaJugada.Color == Enumeradores.Colores.Negro)
    {
      return true;
    }

    if (cartaJugada.Color == cartaEncima.Color)
    {
      return true;
    }

    if (cartaJugada is CartaNormal cartaJ && cartaEncima is CartaNormal cartaE)
    {
      if (cartaJ.Valor == cartaE.Valor)
      {
        return true;
      }
    }

    return false;
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

