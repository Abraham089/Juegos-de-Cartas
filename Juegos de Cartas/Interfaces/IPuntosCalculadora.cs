using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IPuntosJack: IPuntosCalculadora<ICartaJack>
{
  bool EsManoSuave(IEnumerable<ICartaJack> cartas);
  int ContarAses(IEnumerable<ICartaJack> cartas);
}
