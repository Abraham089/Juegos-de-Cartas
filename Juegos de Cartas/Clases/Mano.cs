using System;

namespace Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;

public class Mano<TCarta> : IMano<TCarta> where TCarta : class
{
    private List<TCarta> _cartas = new List<TCarta>();

    public List<TCarta> CartasLista
    {
         get
        {
            return _cartas;
        }
        set
        {
            if (value == null)
            {
                throw new Exception(message: "La lista de cartas no puede ser nula.");
            }
            _cartas = value;
        }
    }

    public int CantidadCartas
    {
        get { return _cartas.Count; }
    }

    public bool EstaVacio
    {
        get { return _cartas.Count == 0; }
    }

    public IReadOnlyList<TCarta> Cartas
    {
        get { return _cartas.AsReadOnly(); }
        private set
        {
            if (value == null)
            {
                throw new Exception(message: "La lista de cartas no puede ser nula.");
            }
            _cartas = value.ToList();
        }
    }
    public Mano()
    {
        CartasLista = new List<TCarta>();
    }

    public void AgregarCarta(TCarta carta)
    {
        if (carta == null)
        {
            throw new Exception(message: "la carta no puede ser nula");
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
            throw new Exception(message: "la carta no puede ser nula");
        }
        _cartas.Remove(carta);
    }
}
