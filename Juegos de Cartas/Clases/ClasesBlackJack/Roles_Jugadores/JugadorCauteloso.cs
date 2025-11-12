using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

// Jugador cauteloso: pide cartas hasta alcanzar o superar un punto de corte configurado
public class JugadorCauteloso : Jugadores<ICartaJack>
{
    public int PuntoCorte
    {
        get; set;
    }
    public JugadorCauteloso(string nombre, int puntoCorte = 17)
    : base(nombre)
    {
        PuntoCorte = puntoCorte;
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
  

    public bool JugarTurno(ICartaJack cartaVisibleDealer)
    {
            var puntos = CalcularPuntos();
            return puntos < PuntoCorte && !SePaso();
    }
}