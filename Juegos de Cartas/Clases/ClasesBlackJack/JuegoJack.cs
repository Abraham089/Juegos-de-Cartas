using System;
using System.ComponentModel.DataAnnotations;
using Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;




namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class JuegoJack : JuegoMain<ICartaJack>
{
    private AdminRondas _adminRondasJack;
    public AdminRondas AdminRondasJack
    {
        get { return _adminRondasJack; }
        set { _adminRondasJack = value; }
    }
    private ImprimirJack? _imprimirJack;
    public ImprimirJack? ImprimirJack
    {
        get { return _imprimirJack; }
        set { _imprimirJack = value; }
    }

    public IJugadores<ICartaJack> Dealer
    {
        get { return Jugadores[Jugadores.Count - 1]; }
        set { Jugadores[Jugadores.Count - 1] = value; }
    }


// CANTOOOOOOOOOOOOOOOOOOOOOOOOOOOO
    public JuegoJack(List<IJugadores<ICartaJack>> jugadores, Deck<ICartaJack> deck)
    : base(jugadores, deck)
    {
        var reglasJack = new ReglasJack();
        var logicaDeTurnos = new LogicaDeTurnos(jugadores);
        var repartirCartas = new RepartirCartasJack(deck);
        ImprimirJack = new ImprimirJack();
        AdminRondasJack = new AdminRondas(repartirCartas, reglasJack, logicaDeTurnos, ImprimirJack);

    }
    
    public void IniciarJuegoJack(int numeroDeRondas)
    {
        ImprimirJack?.MostrarInicioJuego(numeroDeRondas);
        for (int rondaActual = 1; rondaActual <= numeroDeRondas; rondaActual++)
        {
            ImprimirJack?.MostrarInicioRonda(rondaActual);

            AdminRondasJack.RepartidorCartas.RepartirCartas(Jugadores, Dealer);
            AdminRondasJack.LogicaDeTurnos.ReiniciarTurno();
            AdminRondasJack.EjecutarTurnosJugadores(Jugadores, Dealer);

            ImprimirJack?.MostrarResultadosRonda(Jugadores);

        }

         ImprimirJack?.MostrarGanadoresFinales(Jugadores);
       
      
    }
}
