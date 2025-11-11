using System;
using Juegos_de_Cartas.Interfaces;
using System.Collections.Generic;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class LogicaDeTurnos : ITurnosJack
{
    private IList<IJugadores<ICartaJack>> _jugadoresEnTurno;
    private int _indiceJugadorActual;
    private bool _turnoTerminado;
    public IJugadores<ICartaJack> JugadorActual
    {
        get
        {
            if (_jugadoresEnTurno.Count == 0 || _indiceJugadorActual >= _jugadoresEnTurno.Count)
            {
                throw new Exception(message:"No hay un jugador actual valido");
            }
            return _jugadoresEnTurno[_indiceJugadorActual];
        }
      
    }
    

    public bool TurnoTerminado {
        get
        {
            return _turnoTerminado;
        }
        set
        {
            if (value != _turnoTerminado)
            {
                throw new Exception("No se puede establecer TurnoTerminado directamente");
            }
            _turnoTerminado = value;
        }
    }
    public LogicaDeTurnos(IList<IJugadores<ICartaJack>> jugadoresEnTurno)
    {
      
        _jugadoresEnTurno = jugadoresEnTurno;
        _indiceJugadorActual = 0;
        _turnoTerminado = false;
    }
    public bool HayMasJugadores()
    {
       return !_turnoTerminado && _indiceJugadorActual < _jugadoresEnTurno.Count;
    }
    

    public IList<IJugadores<ICartaJack>> ObtenerJugadoresEnTurno()
    {
        return _jugadoresEnTurno;
    }

    public void ReiniciarTurno()
    {
        _indiceJugadorActual = 0;
        _turnoTerminado = false;
    }

    public void SiguienteTurno()
    {
        if (!HayMasJugadores())
        {
            throw new Exception(message:"No hay más jugadores en turno");
        }
        _indiceJugadorActual++;
    }
    

    public void TerminarTurno()
    {
        if (_turnoTerminado)
        {
            throw new Exception(message:"El turno ya ha terminado");
        }
        _turnoTerminado = true;
    }
}
