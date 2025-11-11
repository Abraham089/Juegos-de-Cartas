using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using Juegos_de_Cartas.Enumeradores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases;

public class PuntosJack : PuntosCalculadora<ICartaJack>, IPuntosJack
{
    

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
        return  puntosBase + 1 * (AsesContados - 1) + 11 <= 21;
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
            return 1;
        }
        if (carta.Valor >= ValoresCartaJack.Jota || carta.Valor >= ValoresCartaJack.Reina || carta.Valor >= ValoresCartaJack.Rey)
        {
            return 10;
        }
        if (carta.Valor >= ValoresCartaJack.Dos && carta.Valor <= ValoresCartaJack.Diez)
        {
            return (int)carta.Valor;
        }
        throw new Exception( message: "Valor de carta no reconocido.");   
       
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
