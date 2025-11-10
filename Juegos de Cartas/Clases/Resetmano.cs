using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases;

public abstract class Resetmano<TCarta>: IReinciarMano<TCarta> where TCarta : class
{
    protected readonly IPuntosCalculadora<TCarta> _calculadoraPuntos;
    protected readonly IEstadosJuego<TCarta> _evaluadorEstados;

    public Resetmano(IPuntosCalculadora<TCarta> calculadoraPuntos, IEstadosJuego<TCarta> evaluadorEstados)
    {
        _calculadoraPuntos = calculadoraPuntos ?? throw new ArgumentNullException(nameof(calculadoraPuntos));
        _evaluadorEstados = evaluadorEstados ?? throw new ArgumentNullException(nameof(evaluadorEstados));
    }

    public string FormatearCompleta(IEnumerable<TCarta> cartas)
    {
          if (cartas == null || !cartas.Any())
            return "Mano vacía";

        var cartasList = cartas.ToList();
        var puntos = _calculadoraPuntos.CalcularPuntos(cartasList);
        var cartasStr = string.Join(", ", cartasList);

        var estado = ObtenerEstadoPersonalizado(cartasList);

        return $"[{cartasStr}] = {puntos} puntos{estado}";
    }

     protected abstract string ObtenerEstadoPersonalizado(IList<TCarta> cartas);

}
