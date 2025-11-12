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

    public override bool QuiereCarta()
    {
        var puntos = CalcularMejorPuntuacion();
        // Sigue pidiendo mientras no tenga 21 y no esté en bust
        return puntos < 21;
    }

    private int CalcularMejorPuntuacion()
    {
        if (Mano == null || Mano.EstaVacio) return 0;

        int suma = 0;
        int ases = 0;

        foreach (var carta in Mano.Cartas)
        {
            if (carta == null) continue;
            
            // Contar los ases
            if (carta.Valor == ValoresDeCartaPoker.As)
            {
                suma += 11;
                ases++;
                continue;
            }
            
            // Sumar figuras como 10
            if (carta.Valor == ValoresDeCartaPoker.Jota || 
                carta.Valor == ValoresDeCartaPoker.Reina || 
                carta.Valor == ValoresDeCartaPoker.Rey)
            {
                suma += 10;
                continue;
            }
            
            // Sumar el valor numérico de la carta
            suma += (int)carta.Valor;
        }

        // Ajustar ases de 11 a 1 si la suma excede 21
        while (suma > 21 && ases > 0)
        {
            suma -= 10; // Convertir un As de 11 a 1
            ases--;
        }

        return suma;
    }
}
