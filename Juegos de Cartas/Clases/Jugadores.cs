using System;

namespace Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;

public abstract class Jugadores<TCarta> : IJugadores<TCarta> where TCarta : class
{
    public string Nombre { get;  private set; }

    public IMano<TCarta> Mano { get; private set; }

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
        throw new NotImplementedException();
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
        if (carta == null) throw new ArgumentNullException(nameof(carta));
        Mano.AgregarCarta(carta);
    }
}
