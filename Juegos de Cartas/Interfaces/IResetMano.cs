using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IResetMano: IReinciarMano<ICartaJack>
{
    string FormatearDescripcionCompleta(IEnumerable<ICartaJack> cartas);
}
