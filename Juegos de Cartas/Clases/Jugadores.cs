using System;

namespace Juegos_de_Cartas.Clases;

using Juegos_de_Cartas.Clases.ClasesBlackJack;
using Juegos_de_Cartas.Interfaces;

public abstract class Jugadores<TCarta> : IJugadores<TCarta> where TCarta : class
{
    public string Nombre {
        get
        {
            return Nombre;
        }
        protected set
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
        protected set
        {
            if (value == null)
            {
                throw new Exception(message: "La mano no puede ser nula.");
            }
            Mano = value;
        }
    }

    public int Puntos { get; protected set; }

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
    
  
    

    public TCarta JugarCarta(TCarta cartaSuperior, IJugadores<TCarta>? siguienteJugador = null)
    {
        var random = new Random();
        return Mano.Cartas[random.Next(Mano.Cartas.Count - 1)];
    }

   
 
    public virtual void NuevaMano()
    {
        Mano.Limpiar();
    }
 

    public void RecibirCarta(TCarta carta)
    {
        if (carta == null)
        {
            throw new Exception(message: "la carta no puede ser nula");
        }
        Mano.AgregarCarta(carta);
    }

    public void LimpiarMano()
    {
        Mano.Limpiar();
    }

    public void AgregarVictoria()
    {
        VictoriasAcumuladas++;
    }
    

    public int CalcularPuntos()
    {
        if (Mano == null)
        {
            throw new Exception("La mano no puede ser nula al calcular puntos.");
        }
      
        int puntos = 0;
        foreach (var carta in Mano.Cartas)
        {
           
            var valorProp = carta.GetType().GetProperty("valor");
            if (valorProp != null)
            {
                var valor = valorProp.GetValue(carta);
                if (valor == null)
                {
                    throw new Exception("La propiedad valor de la carta es nula");
                }
                puntos += (int)valor;
            }
            else
            {
                throw new Exception("La carta no tiene una propiedad valor");
            }
        }
        return puntos;
    }
    public bool SePaso()
    {
        return CalcularPuntos() > 21;
    }
}
