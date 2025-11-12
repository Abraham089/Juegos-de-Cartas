using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesBlackJack;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

public class JugadorTemerarioJack : Jugadores<ICartaJack>
{
    public JugadorTemerarioJack(string nombre) : base(nombre)
    {
        Mano = new ManoJack();
    }

    public int CalcularPuntos()
    {
        if (Mano == null)
        {
            throw new Exception("La mano no puede ser nula al calcular puntos.");
        }
        return (Mano as ManoJack)?.CalcularPuntos() ?? 0;
    }
    public bool SePaso()
    {
        return CalcularPuntos() > 21;
    }
    public bool JugarTurno(ICartaJack cartaVisibleDealer)
    {
        var puntos = CalcularPuntos();
        return puntos < 21 && !SePaso();
    }
}
