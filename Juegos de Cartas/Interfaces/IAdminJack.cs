using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesBlackJack;
using Juegos_de_Cartas.Clases;

namespace Juegos_de_Cartas.Interfaces;

public interface AdminJack<IJugador, TCarta> where IJugador : IJugadores<TCarta>  where TCarta : class
{
    void IniciarJuego();
    void JugadorRonda();
    bool JuegoTerminado();   
     int RondasJugadas { get; }
     int TotalRondas { get; }
     IJugador Dealer { get; }   
     IEnumerable<IJugador> Jugadores { get; }

}
