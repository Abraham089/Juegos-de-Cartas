using System;

namespace Juegos_de_Cartas.Interfaces;

public interface IMano<TCarta> where TCarta : class
{
    int CantidadCartas { get; }
    bool EstaVacio { get; }
    IReadOnlyList<TCarta> Cartas { get; }
    void AgregarCarta(TCarta carta);
    void RemoverCarta(TCarta carta);
    void Limpiar();
    TCarta? ObtenerCartaEnPosicion(int indice);

}
