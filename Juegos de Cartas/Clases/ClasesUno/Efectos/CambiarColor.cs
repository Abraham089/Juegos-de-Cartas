using System;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;

namespace Juegos_de_Cartas.Clases.ClasesUno.Efectos;

public class CambiarColor : Interfaces.IEfectoDeCarta
{
  public void Efecto(JuegoUno juego, JugadorAbstractoUno jugadorCausante)
  {
    Enumeradores.Colores colorElegido = jugadorCausante.ElegirColorComodin(); 
        
    juego.EstablecerColorActivo(colorElegido);
  }
}
