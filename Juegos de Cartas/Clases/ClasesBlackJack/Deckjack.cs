using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class DeckJack
{
  
             public static Deck<ICartaPoker> ConstruirMazoCompleto()
        {
            var generadorCartas = new GeneradorCartasJack();
            var cartas = generadorCartas.GenerarCartasCompletas();

            var deck = new Deck<ICartaPoker>(cartas);
            var barajador = new BarajeadorDeck();
            barajador.Barajear(deck);

            return deck;
        }
    
}
