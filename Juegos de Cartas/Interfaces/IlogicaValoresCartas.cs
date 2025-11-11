using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Juegos_de_Cartas.Interfaces
{
    public interface IlogicaValoresCartas: ILogicaDeCartasJack
    {
        int[] ObtenerValores(ICarta<int> carta);

        int SeleccionarMejorValor(int[] ValoresPosibles, int ValorActualMano);
    }
}