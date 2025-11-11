using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.LogicaDeCartas;

public class LogicaDeCartaDiez : ILogicaValorCartaFijas
{
    public int ValorCarta
    {
        get { return 10; }
    }

    public string TipoDeCarta
    {
        get { return "Diez"; }
    }

    public bool AplicarLogica(ICarta<int> carta)
    {
        return EsDiez(carta);
    }

    public int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano)
    {
        if (!AplicarLogica(carta))
        {
            throw new Exception(message: "La carta no es un diez.");
        }
        return ValorCarta;
    }
      private bool EsDiez(ICarta<int> carta)
    {
        return carta.Valor == 10;
    }
}
