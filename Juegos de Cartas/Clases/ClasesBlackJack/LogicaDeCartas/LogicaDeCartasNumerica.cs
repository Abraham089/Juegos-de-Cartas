using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.LogicaDeCartas;

public class LogicaDeCartasNumerica : ILogicaValorCartaFijas
{
    public int ValorCarta => throw new NotImplementedException("Las cartas numericas no tienen un valor fijo.");

    public string TipoDeCarta => "Numerica";

    public bool AplicarLogica(ICarta<int> carta)
    {
        return carta.Valor >= 2 && carta.Valor <= 9 ;
    }

    public int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano)
    {
        if (!AplicarLogica(carta))
        {
            throw new NotImplementedException("La carta no es numerica.");
        }
        return carta.Valor;
    }

    public bool EsCartaNumerica(ICarta<int> carta, int valor)
    {
        return AplicarLogica(carta) && carta.Valor == valor;
    }
    public string CartaNumerica(ICarta<int> carta)
    {
        if (!AplicarLogica(carta))
        {
            throw new NotImplementedException("La carta no es numerica.");
        }
        return carta.Valor switch
        {
            2 or 3 or 4 or 5 or 6 => "Baja",
            7 or 8 => "Media",
            9  => "Alta",
            _ => throw new NotImplementedException("Valor de carta numerica no reconocido.")
        };
    }
    public bool EsCartaBaja(ICarta<int> carta)
    {
        return AplicarLogica(carta) && carta.Valor >= 2 && carta.Valor <= 6;
    }
    public bool EsCartaMedia(ICarta<int> carta)
    {
        return AplicarLogica(carta) && (carta.Valor == 7 || carta.Valor == 8);
    }
    public bool EsCartaAlta(ICarta<int> carta)
    {
        return AplicarLogica(carta) && carta.Valor == 9;
    }
}
