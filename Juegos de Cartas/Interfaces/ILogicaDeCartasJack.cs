using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juegos_de_Cartas.Interfaces
{
    public interface ILogicaDeCartasJack
    {
        int CalcularValor(ICarta<int> carta, IDeck<ICarta<int>> mano, int ValorDelaMano);

        bool AplicarLogica(ICarta<int> carta);
        
        string TipoDeCarta { get; }
    }
}