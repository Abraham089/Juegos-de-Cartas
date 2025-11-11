using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IReglas<TJugador, TCarta> where TJugador : IJugadores<TCarta> where TCarta : class
{
    bool PuedeJugarTurno(TJugador jugador);
    bool DebePedirCarta(TJugador jugador, TCarta cartaVisible);
    bool JugadorEliminado(TJugador jugador);
    bool DealerDebeJugar(TJugador dealer);
}
