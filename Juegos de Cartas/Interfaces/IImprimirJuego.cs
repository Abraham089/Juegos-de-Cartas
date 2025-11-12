using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IImprimirJuego<IJugador> where IJugador : class
  
{
    void MostrarInicioJuego(int totalRondas);
    void MostrarInicioRonda(int numeroRonda);
    void MostrarResultadosRonda(IEnumerable<IJugador> jugadores);
    void MostrarGanadoresFinales(IEnumerable<IJugador> ganadores);
    void MostrarTurnoJugador(IJugador jugador);
    void MostrarAccionJugador(IJugador jugador, string accion, object detalles);
    void MostrarError(string mensaje);
}
