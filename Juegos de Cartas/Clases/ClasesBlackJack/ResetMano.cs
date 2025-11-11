using System;
using System.Collections.Generic;
using System.Linq;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases;


namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class ResetMano : Resetmano<ICartaJack>, IResetMano
{
      public ResetMano(IPuntosJack calculadoraPuntos, IEstadosJack evaluadorEstados) 
        : base(calculadoraPuntos, evaluadorEstados)
    {
        
    }

    public string FormatearDescripcionCompleta(IEnumerable<ICartaJack> cartas)
    {
       return FormatearCompleta(cartas);
    }

    protected override string ObtenerEstadoPersonalizado(IList<ICartaJack> cartas)
    {
        var estadosJack = (IEstadosJack)_evaluadorEstados;
        var puntosJack = (IPuntosJack)_calculadoraPuntos;

        if (estadosJack.EsBlackjack(cartas, cartas.Count))
        {
            return "blackjack";
        }

       else if (estadosJack.SePaso(cartas))
        {
            return "se paso";
        }
        
        
        if (puntosJack.EsManoSuave(cartas))
        {
            return "Mano Suave";
        }
   

        return "";
    }
}

