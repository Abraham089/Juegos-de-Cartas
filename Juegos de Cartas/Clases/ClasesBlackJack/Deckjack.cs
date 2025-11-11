using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public static class DeckJack
{            
 public static Deck<ICartaJack> ConstruirMazoCompleto()
    {
        var generadorCartas = new GeneradorCartasJack();
        var cartas = generadorCartas.GenerarCartasCompletas();

        var deck = new Deck<ICartaJack>(cartas);
        var barajador = new BarajeadorDeck();
        barajador.Barajear(deck);

        return deck;
    }
    
}
