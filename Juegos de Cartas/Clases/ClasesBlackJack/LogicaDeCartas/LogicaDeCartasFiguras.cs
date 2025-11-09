using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.LogicaDeCartas;

public class LogicaDeCartasFiguras : ILogicaValorCartaFijas
{
    public int ValorCarta => 10;

    public string TipoDeCarta => "Figura";

    public bool AplicarLogica(ICarta<int> carta)
    {
        return EsFigura(carta);
    }

    public int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano)
    {
        if (!AplicarLogica(carta))
        {
            throw new NotImplementedException();
        }
        return ValorCarta;
    }
    private bool EsFigura(ICarta<int> carta)
    {
        return carta.Valor == 10 && !EsDiez(carta);
    }

    private bool EsDiez(ICarta<int> carta)
    {
        var descripcion = carta.ToString()?.ToLowerInvariant() ?? "";
        return descripcion.Contains("10") || descripcion.Contains("diez");
    }
    private bool EsJota(ICarta<int> carta)
    {
        var descripcion = carta.ToString()?.ToLowerInvariant() ?? "";
        return descripcion.Contains("j") || descripcion.Contains("jota");
    }
    private bool EsReina(ICarta<int> carta)
    {
        var descripcion = carta.ToString()?.ToLowerInvariant() ?? "";
        return descripcion.Contains("q") || descripcion.Contains("reina");
    }
    private bool EsRey(ICarta<int> carta)
    {
        var descripcion = carta.ToString()?.ToLowerInvariant() ?? "";
        return descripcion.Contains("k") || descripcion.Contains("rey");
    }
    public string Figuras(ICarta<int> carta)
    {
        if (!AplicarLogica(carta))
        {
            throw new NotImplementedException("La carta no es una figura.");
        }
        if (EsJota(carta))
        {
            return "Jota";
        }
        if (EsReina(carta))
        {
            return "Reina";
        }
        if (EsRey(carta))
        {
            return "Rey";
        }
        return "Diez";
    }
    
}
