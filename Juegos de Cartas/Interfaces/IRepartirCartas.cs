using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;


namespace Juegos_de_Cartas.Interfaces;

public interface IRepartirCartas<TCarta> where TCarta : class
{
    void RepartirCartas(IEnumerable<IJugadores<TCarta>> jugadores, IJugadores<TCarta> dealer);
    void RepartirCarta(IJugadores<TCarta> jugador);
    bool DeckVacio { get; }
    Deck<TCarta> Deck { get; set; }
}
