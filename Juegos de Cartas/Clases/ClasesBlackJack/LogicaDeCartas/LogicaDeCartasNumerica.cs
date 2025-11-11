using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.LogicaDeCartas;

public class LogicaDeCartasNumerica : ILogicaValorCartaFijas
{
    public int ValorCarta 
    {
        get
        {
            throw new Exception(message: "El valor de la carta numerica depende de la carta especifica.");
        }
    }

    public string TipoDeCarta
    {
        get { return "Numerica"; }
        
    }

    public bool AplicarLogica(ICarta<int> carta)
    {
        return carta.Valor >= 2 && carta.Valor <= 9 ;
    }

    public int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano)
    {
        if (!AplicarLogica(carta))
        {
            throw new Exception(message: "La carta no es numerica.");
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
            throw new Exception(message: "La carta no es numerica.");
        }
        if (carta.Valor >= 2 && carta.Valor <= 6)
        {
            return "Baja";
        }

        if (carta.Valor == 7 || carta.Valor == 8)
        {
            return "Media";
        }
        if (carta.Valor == 9)
        {
            return "Alta";
        }
        throw new Exception(message: "La carta no es numerica.");
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
