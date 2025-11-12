using System;

namespace Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;

public abstract class Jugadores<TCarta> : IJugadores<TCarta> where TCarta : class
{
    public string Nombre {
        get
        {
            return Nombre;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception(message: "El nombre no puede ser nulo o vacío.");
            }
            Nombre = value;
        }
         }

    public IMano<TCarta> Mano
    {
        get
        {
            return Mano;
        } 
        private set
        {
            if (value == null)
            {
                throw new Exception(message: "La mano no puede ser nula.");
            }
            Mano = value;
        }
    }

    public int Puntos { get; private set; }

    //beria de ir el tipo de jugador
    protected Jugadores(string nombre)
    {
        Nombre = nombre;
        Mano = new Mano<TCarta>();
        Puntos = 0;
    }

    //tipo y mano
    protected Jugadores(string nombre, IMano<TCarta> mano)
    : this(nombre)
    {
        Mano = mano;
    }
    
    // los cosas que puede hacer el jugador 
    

    public TCarta JugarCarta()
    {
        var random = new Random();
        return Mano.Cartas[random.Next(Mano.Cartas.Count - 1)];
    }

    // Por defecto el jugador no pide cartas (se puede sobreescribir)
    public virtual bool QuiereCarta()
    {
        return false;
    }

    public virtual void NuevaMano()
    {
        Mano.Limpiar();
    }
    public virtual void ActualizarPuntos()
    {
        Puntos++;
    }

    public virtual void ReiniciarPuntos()
    {
        Puntos = 0;
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
