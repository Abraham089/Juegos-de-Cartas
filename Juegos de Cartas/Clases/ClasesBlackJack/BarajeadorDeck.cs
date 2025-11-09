using System;

namespace Juegos_de_Cartas.Clases;

using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;

internal class BarajeadorDeck
{
    public void Barajear<T>(Deck<T> deck) where T : class
        {
             deck.Barajear();
        }
}
