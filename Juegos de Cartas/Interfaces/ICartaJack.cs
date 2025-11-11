using System;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Interfaces;

public interface ICartaJack : ICarta<ValoresCartaJack>
{
    Figuras Figura { get; }
    Colores Color { get; }
    int ObtenerValorNumerico(bool asAsOnce = false);
}



