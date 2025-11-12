using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesBlackJack;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class ImprimirJack : IImprimirJuego<IJugadores<ICartaJack>>
{
    public void MostrarAccionJugador(IJugadores<ICartaJack> jugador, string accion, object detalles)
    {
        Console.WriteLine($"Jugador: {jugador.Nombre}, Acción: {accion}");
        if (detalles != null)
        {
            Console.WriteLine($"  {detalles}");
        }
    }

    public void MostrarError(string mensaje)
    {
        Console.WriteLine($"Error: {mensaje}");
    }

    public void MostrarGanadoresFinales(IEnumerable<IJugadores<ICartaJack>> ganadores)
    {
        Console.WriteLine("Ganadores Finales:");
        foreach (var ganador in ganadores)
        {
            Console.WriteLine($"- {ganador.Nombre}");
        }
    }

    

    public void MostrarInicioJuego(int totalRondas)
    {
        Console.WriteLine($"Inicio del juego: {totalRondas} rondas.");
    }

    public void MostrarInicioRonda(int numeroRonda)
    {
        Console.WriteLine($"Inicio de la ronda: {numeroRonda}");
    }

    public void MostrarResultadosRonda(IEnumerable<IJugadores<ICartaJack>> jugadores)
    {
        Console.WriteLine("Resultados de la ronda:");
        foreach (var jugador in jugadores)
        {
            
            Console.WriteLine($"- {jugador.Nombre}: {((ManoJack)jugador.Mano).CalcularPuntos()} puntos");
        }
    }

    public void MostrarTurnoJugador(IJugadores<ICartaJack> jugador)
    {
        Console.WriteLine($"Turno del jugador: {jugador.Nombre}");
    }
    }

