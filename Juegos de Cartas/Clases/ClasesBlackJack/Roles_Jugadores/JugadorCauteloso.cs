using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

// Jugador cauteloso: pide cartas hasta alcanzar o superar un punto de corte configurado
public class JugadorCauteloso : Jugadores<ICartaJack>
{
    public int PuntoCorte
    {
        get; set;
    }
    public JugadorCauteloso(string nombre, int puntoCorte = 17)
    : base(nombre)
    {
        PuntoCorte = puntoCorte;
    }
  

    public override bool JugarTurno(ICartaJack cartaVisibleDealer)
    {
            var puntos = CalcularPuntos();
            return puntos < PuntoCorte && !SePaso();
    }
}