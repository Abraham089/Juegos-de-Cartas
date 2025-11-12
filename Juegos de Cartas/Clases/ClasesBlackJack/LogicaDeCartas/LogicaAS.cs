using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Interfaces;
namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Efectos;

public class LogicaAS : IlogicaValoresCartasAs
{
    public LogicaAS() {}
    public string TipoDeCarta
    {
        get { return "As"; }
    }
    private int[] _valoresPosibles =  { 1, 11 };



    public bool AplicarLogica(ICarta<int> carta)
    {
       return carta.Valor==1;
    }

    public int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano)
    {
        if (!AplicarLogica(carta))
        {
             return carta.Valor;
        }
        if (ValorDelaMano + 11 <= 21)
        {
            return 11;
        }
        return 1;
    }

    public int[] ObtenerValores(ICarta<int> carta)
    {
        return _valoresPosibles;
    }

    public int SeleccionarMejorValor(int[] ValoresPosibles, int ValorActualMano)
    {
        const int limite = 21;
       if(ValorActualMano + 11 <= limite)
        {
            return 11;
        }
        return 1;
    }

    public int MasDeUnAsEnMano(IMano<ICarta<int>> mano, int ValorDelaMano)
    {
        var contadorAs = AsesMultiplesEnMano(mano);
        if (contadorAs == 0)
        {
            return ValorDelaMano;
        }
        int ValorMejorAs = ValorDelaMano;
       
        for (int i = 0; i < contadorAs; i++)
        {
            if (ValorMejorAs + 11 <= 21)
            {
                ValorMejorAs += 10;
             
            }
            else
            {
              break;
            }
        }
        return ValorMejorAs;
    }
    
    private int AsesMultiplesEnMano(IMano<ICarta<int>> mano)
    {
        int contadorAs = 0;
        foreach (var carta in mano.Cartas)
        {
            if (AplicarLogica(carta))
            {
                contadorAs++;
            }
        }
        return contadorAs;
    }
}
