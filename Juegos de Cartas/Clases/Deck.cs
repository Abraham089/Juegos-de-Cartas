using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases;

public class Deck<ICarta> : IDeck<ICarta> where ICarta : class
{
    private List<ICarta> _cartas;

public List<ICarta> Cartas
    {
        get
        {
            return _cartas;
        }
        set
        {
            if (value == null)
            {
                throw new Exception(message: "la coleccion de cartas no puede ser nula");
            }
            _cartas = value;
        }
    }
    private Random _random;
  

    public int CantidadCartas
    {
        get { return _cartas.Count; }
        set
        {
            if (value < 0)
            {
                throw new Exception(message: "La cantidad de cartas no puede ser negativa");
            }

        }
    }

    public bool EstaVacio
    {
        get { return _cartas.Count == 0; }
        set { 
            if (value != (_cartas.Count == 0))
            {
                throw new Exception(message: "No se puede establecer EstaVacio directamente");
            }
        }
    }

    public Deck()
    {
        _cartas = new List<ICarta>();
        _random = new Random();
    }
    public Deck(IEnumerable<ICarta> cartas)
    : this()
    {
        _cartas.AddRange(cartas);
    }

    public void AgregarCarta(ICarta carta)
    {
        if (carta == null)
        {
            throw new Exception(message: "la carta no puede ser nula");
        }
        _cartas.Add(carta);
    }

    public void AgregarCartas(IEnumerable<ICarta> cartas)
    {
        if (cartas == null)
        {
            throw new Exception(message: "la coleccion de cartas no puede ser nula");
        }
        _cartas.AddRange(cartas);
    }

    public void Bareajear()
    {
        for (int i = 0; i < _cartas.Count; i++)
        {
            int j = _random.Next(i, _cartas.Count);
            (_cartas[i], _cartas[j]) = (_cartas[j], _cartas[i]);
        }
    }
    

    public void Limpiar()
    {
        _cartas.Clear();
    }

    public IReadOnlyList<ICarta> ObtenerCartas()
    {
        return _cartas.AsReadOnly();
    }

    public ICarta? TomarCarta()
    {
        if (EstaVacio)
        {
            return null;
        }
        ICarta carta = _cartas[0];
        _cartas.RemoveAt(0);
        return carta;
    }
}
