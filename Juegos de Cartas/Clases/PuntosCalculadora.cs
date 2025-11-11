using System;
using Juegos_de_Cartas.Interfaces;
using System.Collections.Generic;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases;

public abstract class PuntosCalculadora<ICarta> : IPuntosCalculadora<ICarta> where ICarta : class
{
    public virtual int CalcularPuntos(IEnumerable<ICarta> cartas)
    {
        if (cartas == null)
        {
            throw new Exception(message: "La coleccion de cartas no puede ser nula.");
        }
       bool tieneCartas = ContarCartas(cartas) > 0;
        if (!tieneCartas)
        {
            return 0;
        }

        int puntosTotales = 0;
        foreach (var carta in cartas)
        {
            puntosTotales += ObtenerValorCarta(carta);
        }
        return puntosTotales;
    }
    protected abstract int ObtenerValorCarta(ICarta carta);

    protected virtual int ContarCartas(IEnumerable<ICarta> cartas)
    {
      if (cartas == null)
        {
            throw new Exception(message: "La coleccion de cartas no puede ser nula.");
        }
        int contador = 0;
        foreach (var carta in cartas)
        {
            contador++;
        }
        return contador;
    }
    
}
