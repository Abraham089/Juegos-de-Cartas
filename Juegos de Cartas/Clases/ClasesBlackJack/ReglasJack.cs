using System;
using Juegos_de_Cartas.Interfaces;
using   Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;
using Juegos_de_Cartas.Clases.ClasesBlackJack;



namespace Juegos_de_Cartas.Clases;

public class ReglasJack : IReglas<IJugadores<ICartaJack>, ICartaJack>
{
    public ReglasJack() { }

    public bool DealerDebeJugar(IJugadores<ICartaJack> dealer)
    {
        if (dealer == null)
        {
            throw new Exception(message: "El dealer no puede ser null");
        }
        if (dealer is IJugadores<ICartaJack> dealerJack)
        {
            if (dealerJack.Mano is ManoJack manoBlackJack)
            {
                return manoBlackJack.CalcularPuntos() < 17 && !manoBlackJack.SePaso();
            }
        }
        return false;
    }

    public bool DebePedirCarta(IJugadores<ICartaJack> jugador, ICartaJack cartaVisible)
    {
        if (jugador == null)
        {
            throw new Exception(message: "El jugador no puede ser null");
        }
        if (cartaVisible == null)
        {
            throw new Exception(message: "La carta visible no puede ser null");
        }
        if (jugador is IJugadores<ICartaJack> jugadorJack)
        {
            if (jugadorJack.Mano is ManoJack manoBlackJack)
            {
                return manoBlackJack.CalcularPuntos() < 21 && !manoBlackJack.SePaso();
            }
        }
        return false;
    }

    public bool JugadorEliminado(IJugadores<ICartaJack> jugador)
    {
        if (jugador == null)
        {
            throw new Exception(message: "El jugador no puede ser null");
        }
        if (jugador is IJugadores<ICartaJack> jugadorJack)
        {
            if (jugadorJack.Mano is ManoJack manoBlackJack)
            {
                return manoBlackJack.SePaso();
            }
        }
        return false;
    }

    public bool PuedeJugarTurno(IJugadores<ICartaJack> jugador)
    {
        if (jugador == null)
        {
            throw new Exception(message: "El jugador no puede ser null");
        }
        if (jugador is IJugadores<ICartaJack> jugadorJack)
        {
            if (jugadorJack.Mano is ManoJack manoBlackJack)
            {
                return !manoBlackJack.SePaso() && !manoBlackJack.EsBlackjack() && manoBlackJack.CalcularPuntos() < 21;
            }
        }
        return true;
    }
}
