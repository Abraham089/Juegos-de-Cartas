using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

// Jugador cauteloso: pide cartas hasta alcanzar o superar un punto de corte configurado
public class JugadorCauteloso : Jugadores<CartaJack>
{
    public int PuntoCorte { get; private set; }

    public JugadorCauteloso(string nombre, int puntoCorte = 17) : base(nombre)
    {
        if (puntoCorte < 12 || puntoCorte > 20)
        {
            throw new ArgumentException("El punto de corte debe estar entre 12 y 20", nameof(puntoCorte));
        }
        PuntoCorte = puntoCorte;
    }

    public override bool QuiereCarta()
    {
        var puntos = CalcularMejorPuntuacion();
        // Si ya tiene 21 o está en bust (>21) no pide
        if (puntos >= 21) return false;
        // Pide solo si está por debajo del punto de corte
        return puntos < PuntoCorte;
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