using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

// Jugador temerario: pide siempre hasta conseguir 21 o pasarse
public class JugadorTemerario : Jugadores<CartaJack>
{
    public JugadorTemerario(string nombre) : base(nombre)
    {
    }
    public override bool JugarTurno(CartaJack cartaVisibleDealer)
    {
        var puntos = CalcularPuntos();
        return puntos < 21 && !SePaso();
    }
}
