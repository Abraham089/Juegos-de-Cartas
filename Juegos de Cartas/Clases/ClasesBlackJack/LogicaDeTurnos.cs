using System;
using Juegos_de_Cartas.Interfaces;
using System.Collections.Generic;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class LogicaDeTurnos : ITurnosJack
{
    public IJugadores<ICartaJack> JugadorActual => throw new NotImplementedException();

    public bool TurnoTerminado => throw new NotImplementedException();

    public bool HayMasJugadores()
    {
        throw new NotImplementedException();
    }

    public IList<IJugadores<ICartaJack>> ObtenerJugadoresEnTurno()
    {
        throw new NotImplementedException();
    }

    public void ReiniciarTurno()
    {
        throw new NotImplementedException();
    }

    public void SiguienteTurno()
    {
        throw new NotImplementedException();
    }

    public void TerminarTurno()
    {
        throw new NotImplementedException();
    }
}
