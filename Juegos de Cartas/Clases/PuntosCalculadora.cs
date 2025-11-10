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
        if (cartas == null || !cartas.Any()) return 0;

        return cartas.Sum(carta => ObtenerValorCarta(carta));
    }
    protected abstract int ObtenerValorCarta(ICarta carta);

    protected virtual int ContarCartas(IEnumerable<ICarta> cartas)
    {
        return cartas?.Count() ?? 0;
    }
    
}
