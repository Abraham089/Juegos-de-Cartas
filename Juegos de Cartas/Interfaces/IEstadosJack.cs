using System;
using System.Collections.Generic;

namespace Juegos_de_Cartas.Interfaces;

public interface IEstadosJack: IEstadosJuego<ICartaJack>
{
    bool EsBlackjack(IEnumerable<ICartaJack> cartas, int cantidadCartas);
    bool SePaso(IEnumerable<ICartaJack> cartas);
}
