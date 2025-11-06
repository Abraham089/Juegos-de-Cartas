using System;

namespace Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;

public class Mano<TCarta> : IMano<TCarta> where TCarta : class
{
    private readonly List<TCarta> _cartas;

    public int CantidadCartas => _cartas.Count;

    public bool EstaVacio => _cartas.Count == 0;

    public IReadOnlyList<TCarta> Cartas => _cartas.AsReadOnly();

    public Mano()
    {
        _cartas = new List<TCarta>();
    }

    public void AgregarCarta(TCarta carta)
    {
        if (carta == null)
        {
            throw new ArgumentNullException(nameof(carta), "La carta no puede ser nula.");
        }
        _cartas.Add(carta);
    }

    public void Limpiar()
    {
        _cartas.Clear();
    }

    public TCarta? ObtenerCartaEnPosicion(int indice)
    {
        if (indice < 0 || indice >= _cartas.Count)
        {
            return null;
        }
        return _cartas[indice];
    }

    public void RemoverCarta(TCarta carta)
    {
        if (carta == null)
        {
            throw new ArgumentNullException(nameof(carta), "La carta no puede ser nula.");
        }
        _cartas.Remove(carta);
    }
}
