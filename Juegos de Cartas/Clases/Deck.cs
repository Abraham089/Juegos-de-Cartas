using System;
using Juegos_de_Cartas.Interfaces;

namespace Juegos_de_Cartas.Clases;

public class Deck<ICarta> : IDeck<ICarta> where ICarta : class
{
    private List<ICarta> _cartas;
    public List<ICarta> Cartas
  {
    get { return _cartas; }
  }
    
    private readonly Random _random;

    public int CantidadCartas => _cartas.Count;

    public bool EstaVacio => _cartas.Count == 0;

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
        if (carta == null) throw new ArgumentNullException(nameof(carta));
        _cartas.Add(carta);
    }

    public void AgregarCartas(IEnumerable<ICarta> cartas)
    {
        if (cartas == null) throw new ArgumentNullException(nameof(cartas));
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

    internal void Barajear()
    {
        throw new NotImplementedException();
    }
}
