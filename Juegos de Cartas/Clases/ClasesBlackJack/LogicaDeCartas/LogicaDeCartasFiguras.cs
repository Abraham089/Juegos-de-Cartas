using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Juegos_de_Cartas.Enumeradores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.LogicaDeCartas;

public class LogicaDeCartasFiguras : ILogicaValorCartaFijas
{
    public int ValorCarta 
    {
        get { return 10; }
    }

    public string TipoDeCarta
    {
        get { return "Figura"; }
    }

    public bool AplicarLogica(ICarta<int> carta)
    {
        if (carta is ICartaJack cartaJack)
        {
            return cartaJack.Valor == ValoresCartaJack.Jota || cartaJack.Valor == ValoresCartaJack.Reina || cartaJack.Valor == ValoresCartaJack.Rey;
        }
        return false;
    }

    public int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano)
    {
        if (!AplicarLogica(carta))
        {
            throw new Exception(message: "La carta no es una figura.");
        }
        return ValorCarta;
    }
    public string CartaFigura(ICarta<int> carta)
    {
     if (carta is ICartaJack cartaJack)
        {
            if (cartaJack.Valor == ValoresCartaJack.Jota)
            {
                return "Jota";
            }
            if (cartaJack.Valor == ValoresCartaJack.Reina)
            {
                return "Reina";
            }
            if (cartaJack.Valor == ValoresCartaJack.Rey)
            {
                return "Rey";
            }
        }
        throw new Exception(message: "La carta no es una figura.");
    }
 

   

    
}
