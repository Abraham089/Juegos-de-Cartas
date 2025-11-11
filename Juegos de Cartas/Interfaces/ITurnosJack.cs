using System;

namespace Juegos_de_Cartas.Interfaces;

public interface ITurnosJack
{
    void SiguienteTurno();
    IJugadores<ICartaJack> JugadorActual { get; }
    void ReiniciarTurno();
    void TerminarTurno();
    bool TurnoTerminado { get; }
    bool HayMasJugadores();
    IList<IJugadores<ICartaJack>> ObtenerJugadoresEnTurno();



}
