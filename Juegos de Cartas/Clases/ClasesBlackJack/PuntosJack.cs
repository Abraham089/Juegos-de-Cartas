using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Enumeradores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases;

public class PuntosJack : PuntosCalculadora<ICartaJack>, IPuntosJack
{
    

    public bool EsManoSuave(IEnumerable<ICartaJack> cartas)
    {
        if (!cartas.Any(c => c.Valor == ValoresCartaJack.As)) return false;
        
        var cartasList = cartas.ToList();
        var ases = ContarAses(cartasList);
        var puntosBase = cartasList.Where(c => c.Valor != ValoresCartaJack.As).Sum(c => ObtenerValorCarta(c));
        
        return puntosBase + 1 * (ases - 1) + 11 <= 21;
    }

    public int ContarAses(IEnumerable<ICartaJack> cartas)
    {
        return cartas.Count(c => c.Valor == ValoresCartaJack.As);
    }

    public int CalcularPuntos(ICollection<ICartaJack> cartas)
    {
       if (cartas == null || !cartas.Any()) return 0;

        var cartasList = cartas.ToList();
        var ases = ContarAses(cartasList);
        var puntosBase = cartasList.Where(c => c.Valor != ValoresCartaJack.As).Sum(c => ObtenerValorCarta(c));

        return CalcularConAses(puntosBase, ases);
    }


    protected override int ObtenerValorCarta(ICartaJack carta)
    {
        return carta.Valor switch
        {
            ValoresCartaJack.As => 1,
            ValoresCartaJack.Jota or ValoresCartaJack.Reina or ValoresCartaJack.Rey => 10,
            >= ValoresCartaJack.Dos and <= ValoresCartaJack.Diez => (int)carta.Valor,
            _ => throw new InvalidOperationException($"Valor no reconocido: {carta.Valor}")
        };
    }

    private int CalcularConAses(int puntosBase, int cantidadAses)
    {
        if (cantidadAses == 0) return puntosBase;

        int conAsAlto = puntosBase + 11 + (cantidadAses - 1) * 1;
        return conAsAlto <= 21 ? conAsAlto : puntosBase + cantidadAses * 1;
    }
    
}
