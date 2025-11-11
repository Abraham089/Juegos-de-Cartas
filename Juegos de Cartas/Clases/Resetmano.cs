using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases;

public abstract class Resetmano<TCarta>: IReinciarMano<TCarta> where TCarta : class
{
    protected  IPuntosCalculadora<TCarta> _calculadoraPuntos
    {
        get
        {
            return _calculadoraPuntos;
        }
        private set
        {
            if (value == null)
            {
                throw new Exception(message: "CalculadoraPuntos no puede ser null");
            }
            _calculadoraPuntos = value;
        }
    }
    protected  IEstadosJuego<TCarta> _evaluadorEstados
    {
        get
        {
            return _evaluadorEstados;
        }
        private set
        {
            if (value == null)
            {
                throw new Exception(message: "EvaluadorEstados no puede ser null");
            }
            _evaluadorEstados = value;
        }
    }

    public Resetmano(IPuntosCalculadora<TCarta> calculadoraPuntos, IEstadosJuego<TCarta> evaluadorEstados)
    {
        _calculadoraPuntos = calculadoraPuntos;
        _evaluadorEstados = evaluadorEstados;
    }

    public string FormatearCompleta(IEnumerable<TCarta> cartas)
    {
        if (cartas == null)
        {
            throw new Exception(message: "Mano Vacía");
        }
        bool tieneCartas = false;
        foreach (var carta in cartas)
        {
            tieneCartas = true;
            break;
        }

        if (!tieneCartas)
        {
            throw new Exception(message: "Mano Vacía");
        }
     
        var cartasList = cartas.ToList();
        var puntos = _calculadoraPuntos.CalcularPuntos(cartasList);
        var cartasStr = string.Join(", ", cartasList);

        var estado = ObtenerEstadoPersonalizado(cartasList);

        return $"[{cartasStr}] = {puntos} puntos{estado}";
    }

     protected abstract string ObtenerEstadoPersonalizado(IList<TCarta> cartas);

}
