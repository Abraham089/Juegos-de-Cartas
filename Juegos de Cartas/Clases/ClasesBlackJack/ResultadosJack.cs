using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;


namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class ResultadosJack : IResultados<IJugadores<ICartaJack>>
{
    public void DeterminarGanadores(IEnumerable<IJugadores<ICartaJack>> jugadores, IJugadores<ICartaJack> dealer)
    {
        if (jugadores == null)
        {
            throw new Exception(message: "La lista de jugadores no puede ser null.");
        }
       if (dealer == null)
        {
            throw new Exception(message: "El dealer no puede ser null.");
        }
       var puntosDealer = ((ManoJack)dealer.Mano).CalcularPuntos();
        var dealerSePaso = ((ManoJack)dealer.Mano).SePaso();
        foreach (var jugador in jugadores)
        {
            var puntosJugador = ((ManoJack)jugador.Mano).CalcularPuntos();
            var jugadorSePaso = ((ManoJack)jugador.Mano).SePaso();
            if (!jugadorSePaso && (dealerSePaso || puntosJugador > puntosDealer))
            {
                //cambiar implementacion cuando este lo de los jugadores 
              ((dynamic)jugador).AgregarVictoria();
            }
       
             
        }
    }

    public IEnumerable<IJugadores<ICartaJack>> ObtenerGanadores(IEnumerable<IJugadores<ICartaJack>> jugadores)
    {
        if (jugadores == null)
        {
            throw new Exception(message: "La lista de jugadores no puede ser null.");
        } 

        var maxVictorias= jugadores.Max(j => ((dynamic)j).Victorias);
        return jugadores.Where(j => ((dynamic)j).Victorias == maxVictorias);

    }

    public void ReiniciarResultados()
    {
        // Implementación para reiniciar resultados si es necesario
    }
}
