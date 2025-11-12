using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesBlackJack;
using Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class RepartirCartasJack : IRepartirCartas<ICartaJack>
{
    private Deck<ICartaJack> _deck;
    public Deck<ICartaJack> Deck
    {
        get { return _deck; }
        set
        {
            if (value == null)
                throw new Exception(message: "Deck no puede ser null");
            _deck = value;
        }
    }
    
    public RepartirCartasJack(Deck<ICartaJack> deck)
    {
        _deck = new Deck<ICartaJack>();
        Deck = deck;
    }
    public bool DeckVacio 
    {
        get { return _deck.EstaVacio; }
    }

    public void RepartirCarta(IJugadores<ICartaJack> jugador)
    {
       if (jugador == null)
        {
            throw new Exception(message:"El jugador no puede ser null");
        }
        if (DeckVacio)
        {
            throw new Exception(message: "El deck no tiene cartas para repartir");
        }
        var carta = Deck.SacarCarta();
        jugador.RecibirCarta(carta);
     
    }

    public void RepartirCartas(IEnumerable<IJugadores<ICartaJack>> jugadores, IJugadores<ICartaJack> dealer)
    {
        if (jugadores == null || dealer == null)
        {
            throw new Exception(message:"Los jugadores o el dealer no pueden ser null");
        }

        for(int i = 0; i < 2; i++)
        {
           foreach(var jugador in jugadores)
             {
                RepartirCarta(jugador);
            
             
            }
            RepartirCarta(dealer);  
        }
      
    }
}
