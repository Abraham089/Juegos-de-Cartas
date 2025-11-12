using System;
using Juegos_de_Cartas.Interfaces;
using System.Collections.Generic;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class LogicaDeTurnos : ITurnosJack
{
    private IList<IJugadores<ICartaJack>> _jugadoresEnTurno;

    public IList<IJugadores<ICartaJack>> JugadoresEnTurno
    {
        get { return _jugadoresEnTurno; }
        private set
        {
           if (value == null)
              {
                 throw new Exception(message:"JugadoresEnTurno no puede ser null");
              }
            _jugadoresEnTurno = value;
        }
    }
    private int _indiceJugadorActual;
    public int IndiceJugadorActual
    {
        get { return _indiceJugadorActual; }
        private set
        {
            if (value < 0 || value >= _jugadoresEnTurno.Count)
            {
                throw new Exception(message:"IndiceJugadorActual fuera de rango");
            }
            _indiceJugadorActual = value;
        }
      
    }
    private bool _turnoTerminado;
    public bool TurnoFinalizado
    {
        get { return _turnoTerminado; }
        private set
        {
            _turnoTerminado = value;
        }
    
    }
    public IJugadores<ICartaJack> JugadorActual
    {
        get
        {
            if (JugadoresEnTurno.Count == 0 || _indiceJugadorActual >= JugadoresEnTurno.Count)
            {
                throw new Exception(message:"No hay un jugador actual valido");
            }
            return JugadoresEnTurno[_indiceJugadorActual];
        }
      
    }
    

    public bool TurnoTerminado
    {
        get
        {
            return TurnoTerminado;
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
        _jugadoresEnTurno = new List<IJugadores<ICartaJack>>(jugadoresEnTurno);
        IndiceJugadorActual = 0;
        TurnoTerminado = false;
    }
    public bool HayMasJugadores()
    {
       return !TurnoTerminado && IndiceJugadorActual < JugadoresEnTurno.Count;
    }
    

    public IList<IJugadores<ICartaJack>> ObtenerJugadoresEnTurno()
    {
        return JugadoresEnTurno;
    }

    public  void ReiniciarTurno()
    {
        IndiceJugadorActual = 0;
        TurnoTerminado = false;
    }

    public void SiguienteTurno()
    {
        if (!HayMasJugadores())
        {
            throw new Exception(message:"No hay más jugadores en turno");
        }
        IndiceJugadorActual++;
    }
    

    public void TerminarTurno()
    {
        if (_turnoTerminado)
        {
            throw new Exception(message:"El turno ya ha terminado");
        }
        TurnoTerminado = true;
    }
}
