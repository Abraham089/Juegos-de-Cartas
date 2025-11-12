using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IJugadores<TCarta> where TCarta : class
{
    String Nombre { get;  }
    
    int VictoriasAcumuladas { get; }
    IMano<TCarta> Mano { get; }
    int Puntos { get; }
    void LimpiarMano();
    void AgregarVictoria();
    int CalcularPuntos();
    bool SePaso();
    void RecibirCarta(TCarta carta);
    TCarta JugarCarta();
    
  
    
    

}
