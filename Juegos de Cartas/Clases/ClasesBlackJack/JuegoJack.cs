using System;
using Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;


namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class JuegoJack : JuegoMain<ICartaJack>
{
    public JuegoJack(List<IJugadores<ICartaJack>> jugadores, Deck<ICartaJack> deck) : base(jugadores, deck)
    {
    }
    
}
