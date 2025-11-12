using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

// Jugador temerario: pide siempre hasta conseguir 21 o pasarse
public class JugadorTemerario : Jugadores<CartaJack>
{
    public JugadorTemerario(string nombre) : base(nombre)
    {
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
    public bool JugarTurno(CartaJack cartaVisibleDealer)
    {
        var puntos = CalcularPuntos();
        return puntos < 21 && !SePaso();
    }
}
