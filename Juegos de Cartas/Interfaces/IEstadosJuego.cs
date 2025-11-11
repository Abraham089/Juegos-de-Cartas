using System;
using System.Collections.Generic;

namespace Juegos_de_Cartas.Interfaces;

public interface IEstadosJuego<ICarta> where ICarta : class
{
    bool EsEstadoGanador(IEnumerable<ICarta> cartas, int cantidad);
    bool EsEstadoPerdedor(IEnumerable<ICarta> cartas);
}
