using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesBlackJack;
using Juegos_de_Cartas.Clases.Enumeradores;


namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class AdminRondas : IAdminRondas<IJugadores<ICartaJack>, ICartaJack>
{
    private IRepartirCartas<ICartaJack>? _repartidorCartas;
    public IRepartirCartas<ICartaJack> RepartidorCartas
    {
        get
        {
            if (_repartidorCartas == null)
            {
                throw new Exception(message: "El repartidor de cartas no ha sido inicializado.");
            }
            return _repartidorCartas;
        }
        set
        {
            if (value == null)
            {
                throw new Exception(message: "El repartidor de cartas no puede ser null");
            }
            _repartidorCartas = value;
        }
    }
private IReglas<IJugadores<ICartaJack>, ICartaJack> _reglasJack = new ReglasJack();
public IReglas<IJugadores<ICartaJack>, ICartaJack> ReglasJack
    {
        get { return _reglasJack; }
        set
        {
            if (value == null)
            {
                throw new Exception(message: "Las reglas no pueden ser null");
            }
            _reglasJack = value;
        }
    }


    private ITurnosJack? _logicaDeTurnos;
    public ITurnosJack LogicaDeTurnos
    {
        get
        {
            if (_logicaDeTurnos == null)
            {
                throw new Exception(message: "La logica de turnos no ha sido inicializada.");
            }
            return _logicaDeTurnos;
        }
        set
        {
            if (value == null)
            {
                throw new Exception(message: "La logica de turnos no puede ser null");
            }
            _logicaDeTurnos = value;
        }
    }
    private ImprimirJack? _imprimirJack=new ImprimirJack();
    public ImprimirJack? ImprimirJack
    {
        get { return _imprimirJack; }
        set
        {
            if (value == null)
            {
                throw new Exception(message: "El impresor no puede ser null");
            }
            _imprimirJack = value;
        }
    }
    public AdminRondas(IRepartirCartas<ICartaJack> repartirCartas, IReglas<IJugadores<ICartaJack>, ICartaJack> reglasJack, LogicaDeTurnos logicaDeTurnos, ImprimirJack? imprimirJack)
    {
        RepartidorCartas = repartirCartas;
        ReglasJack = reglasJack;
        LogicaDeTurnos = logicaDeTurnos;
        ImprimirJack = imprimirJack;
    }
    public void EjecutarTurnoDealer(IJugadores<ICartaJack> dealer)
    {
        ImprimirJack?.MostrarTurnoJugador(dealer);
        var carta = dealer.Mano.Cartas.First();
        while (ReglasJack.DealerDebeJugar(dealer))
        {
            RepartidorCartas.RepartirCarta(dealer);
            ImprimirJack?.MostrarAccionJugador(dealer, "El dealer pidió carta", dealer.Mano);
        }

       
    }

    public void EjecutarTurnosJugadores(IEnumerable<IJugadores<ICartaJack>> jugadores, IJugadores<ICartaJack> dealer)
    {
        var carta = dealer.Mano.Cartas.First();

        foreach (var jugador in jugadores)
        {
            while (ReglasJack.PuedeJugarTurno(jugador) && ReglasJack.DebePedirCarta(jugador, carta))
            {
                RepartidorCartas.RepartirCarta(jugador);
            }
        }

    }

    public void FinalizarRonda(IEnumerable<IJugadores<ICartaJack>> jugadores, IJugadores<ICartaJack> dealer)
    {
        
        ImprimirJack?.MostrarResultadosRonda(jugadores.ToList().Append(dealer).ToList());
          
    }

    public void PrepararRonda(IEnumerable<IJugadores<ICartaJack>> jugadores, IJugadores<ICartaJack> dealer)
    {
        foreach (var jugador in jugadores)
        {
            jugador.Mano.Limpiar();

        }
        dealer.Mano.Limpiar();
        RepartidorCartas.RepartirCartas(jugadores, dealer);

        LogicaDeTurnos.ReiniciarTurno();

    }
}
