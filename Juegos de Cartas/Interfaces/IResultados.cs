using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IResultados<TJugador> where TJugador : class
{
    void DeterminarGanadores(IEnumerable<TJugador> jugadores, TJugador dealer);
    IEnumerable<TJugador> ObtenerGanadores(IEnumerable<TJugador> jugadores);

}
