using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IDeck<TCarta> where TCarta : class
{
    int CantidadCartas { get; }
    bool EstaVacio { get; }
    void Bareajear();
    TCarta? TomarCarta();
    void AgregarCarta(TCarta carta);
    void AgregarCartas(IEnumerable<TCarta> cartas);
    void Limpiar();
    IReadOnlyList<TCarta> ObtenerCartas();
    TCarta SacarCarta();
    
}
