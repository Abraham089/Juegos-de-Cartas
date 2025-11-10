using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Interfaces;


namespace Juegos_de_Cartas.Clases;

public abstract class EstadoJuego<ICarta> : IEstadosJuego<ICarta> where ICarta : class
{
    protected readonly IPuntosCalculadora<ICarta> _calculadoraPuntos;

    public EstadoJuego(IPuntosCalculadora<ICarta> calculadoraPuntos)
    {
       _calculadoraPuntos = calculadoraPuntos ?? throw new ArgumentNullException(nameof(calculadoraPuntos));
    }
    public abstract bool EsEstadoGanador(IEnumerable<ICarta> cartas, int cantidad);
    public abstract bool EsEstadoPerdedor(IEnumerable<ICarta> cartas);
    protected virtual int ObtenerPuntos(IEnumerable<ICarta> cartas)
    {
        return _calculadoraPuntos.CalcularPuntos(cartas);
    }
 

    
  
}
