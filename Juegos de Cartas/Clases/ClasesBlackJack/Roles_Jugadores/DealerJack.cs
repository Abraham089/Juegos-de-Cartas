using System;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

public class DealerJack : Jugadores<CartaJack>
{
    public DealerJack(string nombre) : base("Dealer")
    {
    }
    public override bool JugarTurno(CartaJack cartaVisibleDealer)
    {
          var puntos = CalcularPuntos();
        return puntos < 17 && !SePaso();
    }
}
