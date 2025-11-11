using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IReinciarMano<ICarta> where ICarta : class
{
  string FormatearCompleta(IEnumerable<ICarta> cartas);
}
