using System;
using Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesBlackJack;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;

// Helpers para calcular la puntuación de una mano en Blackjack
internal static class BlackJackHelpers
{
	public static int CalcularMejorPuntuacion(IMano<CartaJack> mano)
	{
		if (mano == null || mano.EstaVacio) return 0;

		int suma = 0;
		int ases = 0;

		foreach (var c in mano.Cartas)
		{
			if (c == null) continue;
			if (c.Valor == ValoresDeCartaPoker.As)
			{
				suma += 11;
				ases++;
			}
			else if (c.Valor == ValoresDeCartaPoker.Jota || c.Valor == ValoresDeCartaPoker.Reina || c.Valor == ValoresDeCartaPoker.Rey)
			{
				suma += 10;
			}
			else
			{
				suma += (int)c.Valor;
			}
		}

		// Ajustar ases de 11 a 1 si suma > 21
		while (suma > 21 && ases > 0)
		{
			suma -= 10; // convertir un As de 11 a 1
			ases--;
		}

		return suma;
	}
}

// Jugador cauteloso: pide cartas hasta alcanzar o superar un punto de corte configurado.
public class JugadorCauteloso : Jugadores<CartaJack>
{
	public int PuntoCorte { get; private set; }

	public JugadorCauteloso(string nombre, int puntoCorte = 17) : base(nombre)
	{
		PuntoCorte = puntoCorte;
	}

	public override bool QuiereCarta()
	{
		var puntos = BlackJackHelpers.CalcularMejorPuntuacion(Mano);
		// Si ya tiene 21 o está en bust (>21) no pide.
		if (puntos >= 21) return false;
		// Pide solo si está por debajo del punto de corte
		return puntos < PuntoCorte;
	}
}

// Jugador temerario: pide siempre hasta conseguir 21 o pasarse.
public class JugadorTemerario : Jugadores<CartaJack>
{
	public JugadorTemerario(string nombre) : base(nombre)
	{
	}

	public override bool QuiereCarta()
	{
		var puntos = BlackJackHelpers.CalcularMejorPuntuacion(Mano);
		// Sigue pidiendo mientras no tenga 21 y no esté en bust
		return puntos < 21;
	}
}

