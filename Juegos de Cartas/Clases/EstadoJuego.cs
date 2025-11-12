using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Interfaces;


namespace Juegos_de_Cartas.Clases;

public abstract class EstadoJuego<ICarta> : IEstadosJuego<ICarta> where ICarta : class
{
    protected IPuntosCalculadora<ICarta> _calculadoraPuntos;

    public EstadoJuego(IPuntosCalculadora<ICarta> calculadoraPuntos)
    {
        if (calculadoraPuntos == null)
            throw new Exception(message: "CalculadoraPuntos no puede ser null");
        _calculadoraPuntos = calculadoraPuntos;
    }

    public abstract bool EsEstadoGanador(IEnumerable<ICarta> cartas, int cantidad);
    public abstract bool EsEstadoPerdedor(IEnumerable<ICarta> cartas);
    protected virtual int ObtenerPuntos(IEnumerable<ICarta> cartas)
    {
        return _calculadoraPuntos.CalcularPuntos(cartas);
    }
}
