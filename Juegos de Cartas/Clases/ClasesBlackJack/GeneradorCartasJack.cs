using System;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;
internal class GeneradorCartasJack
{
         public List<ICartaPoker> GenerarCartasCompletas()
        {
            var cartas = new List<ICartaPoker>();

            foreach (Figuras figura in Enum.GetValues<Figuras>())
            {
                foreach (ValoresDeCartaPoker valor in Enum.GetValues<ValoresDeCartaPoker>())
                {
                    cartas.Add(new CartaJack(valor, figura));
                }
            }
            
            return cartas;
        }
}
