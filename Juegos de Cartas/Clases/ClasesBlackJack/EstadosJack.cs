using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases;
using System.Collections.Generic;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class EstadosJack: EstadoJuego<ICartaJack>, IEstadosJack
{
  

    public EstadosJack(IPuntosCalculadora<ICartaJack> calculadoraPuntos) 
    : base(calculadoraPuntos)
    {
    }

    

    public bool EsBlackjack(IEnumerable<ICartaJack> cartas, int cantidadCartas)
    {
        return cantidadCartas == 2 && ObtenerPuntos(cartas) == 21;
    }

    public bool SePaso(IEnumerable<ICartaJack> cartas)
    {
         return ObtenerPuntos(cartas) > 21;
    }

    public override bool EsEstadoGanador(IEnumerable<ICartaJack> cartas, int cantidad)
    {
         return EsBlackjack(cartas, cantidad);
    }

    public override bool EsEstadoPerdedor(IEnumerable<ICartaJack> cartas)
    {
         return SePaso(cartas);
    }
}
