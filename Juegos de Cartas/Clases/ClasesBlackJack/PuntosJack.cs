using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using Juegos_de_Cartas.Enumeradores;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesBlackJack.LogicaDeCartas;
using Juegos_de_Cartas.Clases.ClasesBlackJack.Efectos;

namespace Juegos_de_Cartas.Clases;

public class PuntosJack : PuntosCalculadora<ICartaJack>, IPuntosJack
{
    private LogicaDeCartasNumerica _logicaNumerica;

    public LogicaDeCartasNumerica LogicaNumerica
    {
        get { return _logicaNumerica; }
    }
    private LogicaDeCartasFiguras _logicaFiguras;

    public LogicaDeCartasFiguras LogicaFiguras
    {
        get { return _logicaFiguras; }
    }
    private LogicaDeCartaDiez _logicaDiez;
    public LogicaDeCartaDiez LogicaDiez
    {
        get { return _logicaDiez; }
    }
    private LogicaAS _logicaAs;
    public LogicaAS LogicaAs
    {
        get { return _logicaAs; }
    }
    public PuntosJack()
    {
        _logicaNumerica = new LogicaDeCartasNumerica();
        _logicaFiguras = new LogicaDeCartasFiguras();
        _logicaDiez = new LogicaDeCartaDiez();
    _logicaAs = new LogicaAS();
    }
    public bool EsManoSuave(IEnumerable<ICartaJack> cartas)
    {

        bool tieneAs = false;
        foreach (var carta in cartas)
        {
            if (carta.Valor == ValoresCartaJack.As)
            {
                tieneAs = true;
                break;
            }
        }
        if (!tieneAs)
        {
            return false;
        }
        var puntosBase = 0;
        var AsesContados = ContarAses(cartas);
        foreach (var carta in cartas)
        {
            if (carta.Valor != ValoresCartaJack.As)
            {
                puntosBase += ObtenerValorCarta(carta);
            }
        }
        return puntosBase + 1 * (AsesContados - 1) + 11 <= 21;
    }

    public int ContarAses(IEnumerable<ICartaJack> cartas)
    {
        return cartas.Count(card => card.Valor == ValoresCartaJack.As);
    }

    public int CalcularPuntos(ICollection<ICartaJack> cartas)
    {

        if (cartas == null || cartas.Count == 0)
        {
            return 0;
        }

        var cartasList = cartas;
        var ases = ContarAses(cartasList);
        var puntosBase = 0;
        foreach (var carta in cartasList)
        {
            if (carta.Valor != ValoresCartaJack.As)
            {
                puntosBase += ObtenerValorCarta(carta);
            }
        }

        return CalcularConAses(puntosBase, ases);
    }


    protected override int ObtenerValorCarta(ICartaJack carta)
    {
        if (carta.Valor == ValoresCartaJack.As)
        {
            var cartaIntAs = carta as ICarta<int>;
            var deckVacio = new Deck<ICarta<int>>();
            if (cartaIntAs != null && LogicaAs.AplicarLogica(cartaIntAs))
                return LogicaAs.CalcularValor(cartaIntAs, deckVacio, 0);
            return 1;
        }

        var cartaInt = carta as ICarta<int>;
        if (cartaInt != null)
        {
            var deckVacio = new Deck<ICarta<int>>();
            if (LogicaFiguras.AplicarLogica(cartaInt))
                return LogicaFiguras.CalcularValor(cartaInt, deckVacio, 0);

            if (LogicaDiez.AplicarLogica(cartaInt))
                return LogicaDiez.CalcularValor(cartaInt, deckVacio, 0);

            if (LogicaNumerica.AplicarLogica(cartaInt))
                return LogicaNumerica.CalcularValor(cartaInt, deckVacio, 0);
        }

        throw new Exception("Valor de carta no reconocido.");
    }

    private int CalcularConAses(int puntosBase, int cantidadAses)
    {
        if (cantidadAses == 0)
        {
            return puntosBase;
        }
        var puntosConUnAsOnce = puntosBase + 11 + (cantidadAses - 1) * 1;
        if (puntosConUnAsOnce <= 21)
        {
            return puntosConUnAsOnce;
        }
        else
        {
            return puntosBase + cantidadAses * 1;
        }
    }
}
