using System;

namespace Juegos_de_Cartas.Clases;

using Juegos_de_Cartas.Clases.ClasesBlackJack;
using Juegos_de_Cartas.Interfaces;

public abstract class Jugadores<TCarta> : IJugadores<TCarta> where TCarta : class
{
    protected string _nombre;
    public string Nombre
    {
        get
        {
            return _nombre;
        }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception(message: "El nombre no puede ser nulo o vacío.");
            }
            _nombre = value;
        }
    }

    protected IMano<TCarta> _mano;
    public IMano<TCarta> Mano
    {
        get
        {
            return _mano;
        }
        protected set
        {
            if (value == null)
            {
                throw new Exception(message: "La mano no puede ser nula.");
            }
            _mano = value;
        }
    }


    public int VictoriasAcumuladas
    {
        get
        {
            return VictoriasAcumuladas;
        }
        private set
        {
            if (value < 0)
            {
                throw new Exception(message: "Las victorias acumuladas no pueden ser negativas.");
            }
            VictoriasAcumuladas = value;
        }
    }

    protected Jugadores(string nombre)
    {
        Nombre = nombre;
        VictoriasAcumuladas = 0;
    }

    protected Jugadores(string nombre, IMano<TCarta> mano)
    : this(nombre)
    {
        Mano = mano;
    }
    
 

    public void RecibirCarta(TCarta carta)
    {
        if (carta == null)
        {
            throw new Exception(message: "la carta no puede ser nula");
        }
        Mano.AgregarCarta(carta);
    }
}
