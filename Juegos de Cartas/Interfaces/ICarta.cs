using System;

namespace Juegos_de_Cartas.Interfaces;

public interface ICarta<TValueCarta>
{
    TValueCarta? Valor { get; }
    
}
