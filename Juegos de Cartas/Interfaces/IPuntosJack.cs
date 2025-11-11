using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IPuntosCalculadora<ICarta> where ICarta : class
{
  int CalcularPuntos(IEnumerable<ICarta> cartas);
}
