using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IJugadores<TCarta> where TCarta : class
{
    String Nombre { get;  }
    
    // Propiedad donde se pueda escoger que tipo de jugador puede ser 

    IMano<TCarta> Mano { get; }
    int Puntos { get;  }

    // Acciones de jugadores que pueda realizar 

    void RecibirCarta(TCarta carta);
    // metodo donde se pueda ver si el jugador puede jugar una carta bool
    void NuevaMano();
    
    // Decisión de si el jugador quiere pedir otra carta (true = pedir)
    bool QuiereCarta();

    

}
