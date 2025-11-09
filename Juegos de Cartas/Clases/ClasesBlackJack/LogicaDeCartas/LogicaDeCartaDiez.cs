using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.LogicaDeCartas;

public class LogicaDeCartaDiez : ILogicaValorCartaFijas
{
    public int ValorCarta => 10;

    public string TipoDeCarta => "Diez";

    public bool AplicarLogica(ICarta<int> carta)
    {
        return EsDiez(carta);
    }

    public int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano)
    {
        if (!AplicarLogica(carta))
        {
            throw new NotImplementedException("La carta no es un diez.");
        }
        return ValorCarta;
    }
      private bool EsDiez(ICarta<int> carta)
    {
        if (carta.Valor != 10) return false;
        
        var descripcion = carta.ToString()?.ToLowerInvariant() ?? "";
        return descripcion.Contains("10") || descripcion.Contains("diez");
    }
}
