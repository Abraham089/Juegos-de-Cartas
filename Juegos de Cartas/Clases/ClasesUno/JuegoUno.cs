using System;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public class JuegoUno : JuegoMain<CartaUnoAbstracta>
{
  protected Enumeradores.Colores _colorActivo;

  public Enumeradores.Colores ColorActivo
  {
      get { return _colorActivo; }
      protected set { _colorActivo = value; } 
  }
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
  protected int _saltosAcumulados = 1;
  public JuegoUno(List<IJugadores<CartaUnoAbstracta>> jugadores, Deck<CartaUnoAbstracta> deck) : base(jugadores, deck)
  {
  }

  public void EstablecerColorActivo(Enumeradores.Colores nuevoColor)
  {
    _colorActivo = nuevoColor;
  }
  public void CambiarDireccion()
  {
    _sentido *= -1;
  }
  public void SaltarProximoTurno(int cantidad)
  {
    _saltosAcumulados += cantidad;
  }
  public void ForzarRoboACantidad(IJugadores<CartaUnoAbstracta> jugadorAfectado, int cantidad)
{
    for (int i = 0; i < cantidad; i++)
    {
        CartaUnoAbstracta cartaRobada = RobarCartaDelMazo(); 
        
        jugadorAfectado.RecibirCarta(cartaRobada); 
    }
}


public override void HacerJugada()
{
    var jugadorActual = (JugadorAbstractoUno)JugadorActual;
    CartaUnoAbstracta cartaSuperior = CartaEncima;
    IJugadores<CartaUnoAbstracta> siguiente = ObtenerSiguienteJugador();

    CartaUnoAbstracta cartaElegida = jugadorActual.JugarCarta(cartaSuperior, siguiente);

    if (cartaElegida != null)
    {
        CartasUsadas.AgregarCarta(cartaElegida);
        AplicarEfectos(cartaElegida); 
        
        SiguienteJugador(skip: _saltosAcumulados); 
        
        _saltosAcumulados = 1; 
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
        
        SiguienteJugador(skip: _saltosAcumulados); 
        
        _saltosAcumulados = 1; 
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
        efecto.Efecto(this, (JugadorAbstractoUno)JugadorActual);
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

