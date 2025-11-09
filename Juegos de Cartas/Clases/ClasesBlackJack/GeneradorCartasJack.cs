using System;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;
internal class GeneradorCartasJack
{
         public List<ICartaJack> GenerarCartasCompletas()
        {
            var cartas = new List<ICartaJack>();

            foreach (Figuras figura in Enum.GetValues<Figuras>())
            {
                foreach (ValoresCartaJack valor in Enum.GetValues<ValoresCartaJack>())
                {
                    cartas.Add(new CartaJack(valor, figura));
                }
            }
            
            return cartas;
        }
}
