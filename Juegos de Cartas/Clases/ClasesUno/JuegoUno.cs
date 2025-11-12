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
    IJugadores<CartaUnoAbstracta> siguiente = ObtenerSiguienteJugador();

    CartaUnoAbstracta cartaElegida = jugadorActual.JugarCarta(cartaSuperior, siguiente); //jugadorActual.JugarCarta(cartaSuperior); 

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

        CartaUnoAbstracta cartaJugable = jugadorActual.DecidirJugarCartaRobada(cartaRobada, cartaSuperior, siguiente);

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

  public static bool SePuedeJugar(CartaUnoAbstracta cartaJugada, CartaUnoAbstracta cartaEncima)
  {
    bool jugable = true;
    if (cartaJugada.Color != cartaEncima.Color && cartaJugada.Color != Enumeradores.Colores.Negro)
    {
      jugable = false;
    }
    if(cartaJugada is CartaNormal && cartaEncima is CartaNormal)
    {
      if(cartaJugada.Valor != cartaEncima.Valor)
      {
        return false;
      }
    }

    return jugable;
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
  public IJugadores<CartaUnoAbstracta> ObtenerSiguienteJugador()
{
    int indiceActual = _indiceJugadorAcutal; 
    
    int indiceSiguiente = (indiceActual + 1) % Jugadores.Count; 
    
    return Jugadores[indiceSiguiente];
}
}

