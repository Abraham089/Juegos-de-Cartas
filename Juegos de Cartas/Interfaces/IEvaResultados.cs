using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IEvaResultados<TJugador> where TJugador : class
{
    void EvaluarResultados(IEnumerable<TJugador> jugadores, TJugador dealer);
    IEnumerable<TJugador> ObtenerGanadoresFinales(IEnumerable<TJugador> jugadores);
    void ReiniciarEvaluacion();
}
