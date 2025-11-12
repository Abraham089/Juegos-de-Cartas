using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IJugadores<TCarta> where TCarta : class
{
    String Nombre { get;  }
    
    int VictoriasAcumuladas { get; }
    IMano<TCarta> Mano { get; }
    void RecibirCarta(TCarta carta);
    
}
