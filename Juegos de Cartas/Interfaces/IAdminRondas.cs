using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IAdminRondas<IJugador, ICarta>
    where IJugador : class
    where ICarta : class
{
    void PrepararRonda(IEnumerable<IJugador> jugadores, IJugador dealer);
    void EjecutarTurnosJugadores(IEnumerable<IJugador> jugadores, IJugador dealer);
    void EjecutarTurnoDealer(IJugador dealer);
    void FinalizarRonda(IEnumerable<IJugador> jugadores, IJugador dealer);
}
