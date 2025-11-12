using System;
using System.Collections.Generic;
using System.Linq;
using Juegos_de_Cartas.Clases;
using Juegos_de_Cartas.Clases.ClasesBlackJack;
using Juegos_de_Cartas.Clases.ClasesBlackJack.Roles_Jugadores;
using Juegos_de_Cartas.Clases.ClasesUno;
using Juegos_de_Cartas.Clases.ClasesUno.Jugadores;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.ClasesUno.Efectos;

namespace Juegos_de_Cartas;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("JUEGOS DE CARTAS\n");
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("1. Simular Blackjack 21");
            Console.WriteLine("2. Simular UNO Clasico");
            Console.WriteLine("3. Salir\n");
            Console.Write("Selecciona una opcion (1-3): ");
            var opcion = Console.ReadLine();

            if (opcion == "1")
            {
                SimularBlackjack();
            }
            else if (opcion == "2")
            {
                SimularUno();
            }
            else if (opcion == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
           
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void SimularUno()
    {
        Console.WriteLine("\nConfigurando simulación de UNO...\n");
        var jugadoresUno = new List<IJugadores<CartaUnoAbstracta>>
        {
            new JugadorAleatorio("Elena Relajada"),
            new JugadorCalculador("Fernando Estratega"),
            new JugadorAleatorio("Gloria Espontánea"),
            new JugadorCalculador("Héctor Competitivo")
        };
        foreach (var jugador in jugadoresUno)
        {
            var manoProp = jugador.GetType().GetProperty("Mano");
            if (manoProp != null && manoProp.CanWrite)
                manoProp.SetValue(jugador, new Mano<CartaUnoAbstracta>());
            else if (jugador is Jugadores<CartaUnoAbstracta> jugadorBase)
            {
                var field = typeof(Jugadores<CartaUnoAbstracta>).GetField("_mano", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (field != null)
                    field.SetValue(jugadorBase, new Mano<CartaUnoAbstracta>());
            }
        }
        var deckUno = new Deck<CartaUnoAbstracta>();
        foreach (Colores color in new[] { Colores.Rojo, Colores.Azul, Colores.Verde, Colores.Amarillo })
        {
            deckUno.AgregarCarta(new CartaNormal(0, color));
            for (int i = 1; i <= 9; i++)
            {
                deckUno.AgregarCarta(new CartaNormal(i, color));
                deckUno.AgregarCarta(new CartaNormal(i, color));
            }
            deckUno.AgregarCarta(new CartaTrampa(1, color, new List<IEfectoDeCarta> { new SaltarTurno() }));
            deckUno.AgregarCarta(new CartaTrampa(1, color, new List<IEfectoDeCarta> { new SaltarTurno() }));
            deckUno.AgregarCarta(new CartaTrampa(2, color, new List<IEfectoDeCarta> { new GirarSentido() }));
            deckUno.AgregarCarta(new CartaTrampa(2, color, new List<IEfectoDeCarta> { new GirarSentido() }));
            deckUno.AgregarCarta(new CartaTrampa(3, color, new List<IEfectoDeCarta> { new TomarCarta(2) }));
            deckUno.AgregarCarta(new CartaTrampa(3, color, new List<IEfectoDeCarta> { new TomarCarta(2) }));
        }
        for (int i = 0; i < 4; i++)
        {
            deckUno.AgregarCarta(new CartaTrampa(4, Colores.Negro, new List<IEfectoDeCarta> { new CambiarColor() }));
            deckUno.AgregarCarta(new CartaTrampa(5, Colores.Negro, new List<IEfectoDeCarta> { new CambiarColor(), new TomarCarta(4) }));
        }

        Console.WriteLine("Arrancando Uno...");
        Console.WriteLine("Descripción de jugadores:");
        Console.WriteLine("- JugadorAleatorio: juega una carta válida al azar si tiene.");
        Console.WriteLine("- JugadorCalculador: elige cartas estratégicamente según la situación.");
        Console.Write("Jugadores: ");
        Console.WriteLine(string.Join(", ", jugadoresUno.ConvertAll(j => j.Nombre)));
        Console.WriteLine("Repartiendo 7 cartas a cada jugador...");
        for (int i = 0; i < 7; i++)
        {
            foreach (var jugador in jugadoresUno)
            {
                var carta = deckUno.TomarCarta();
                if (carta != null)
                    jugador.RecibirCarta(carta);
            }
        }

        var descarte = new List<CartaUnoAbstracta>();
        CartaUnoAbstracta? primeraCarta = deckUno.TomarCarta();
        while (primeraCarta == null || primeraCarta.Color == Colores.Negro)
        {
            if (primeraCarta != null)
                deckUno.AgregarCarta(primeraCarta);
            primeraCarta = deckUno.TomarCarta();
        }
        descarte.Add(primeraCarta);
        Console.WriteLine($"Carta inicial en descarte: [{primeraCarta.GetType().Name}] {primeraCarta.Color}");

        int turno = 0;
        bool juegoTerminado = false;
        int maxJugadas = 12;
        bool sentidoHorario = true;
        int saltarTurno = -1;

        Console.WriteLine("Simulando 12 jugadas (muestra de acciones)...");
        while (!juegoTerminado && turno < maxJugadas)
        {
            var cartaEncima = descarte.Last();
            Console.WriteLine($"-- Después de la jugada {turno + 1} --");
            Console.WriteLine($"Carta superior: {cartaEncima.GetType().Name}");
            int jugadoresCount = jugadoresUno.Count;
            int i = sentidoHorario ? 0 : jugadoresCount - 1;
            int paso = sentidoHorario ? 1 : -1;
            int procesados = 0;
            while (procesados < jugadoresCount)
            {
                var jugador = jugadoresUno[i];
                if (saltarTurno == i)
                {
                    Console.WriteLine($"- {jugador.Nombre}: turno saltado por efecto de carta trampa.");
                    saltarTurno = -1;
                    i += paso;
                    procesados++;
                    continue;
                }
                var jugada = jugador is JugadorAbstractoUno jabs ? jabs.JugarCarta(cartaEncima, null) : null;
                string accion;
                bool efectoAplicado = false;
                if (jugada != null && (jugada.Color == cartaEncima.Color || (jugada is CartaNormal cnj && cartaEncima is CartaNormal cnc && cnj.Valor == cnc.Valor) || jugada.Color == Colores.Negro))
                {
                    if (jugador.Mano is Mano<CartaUnoAbstracta> mano && jugada != null)
                        mano.RemoverCarta(jugada);
                    if (jugada != null)
                        descarte.Add(jugada);
                    string detalleCarta = jugada != null ? $"[{jugada.GetType().Name} {jugada.Color}" : "[Ninguna]";
                    if (jugada is CartaNormal cnj2)
                        detalleCarta += $" {cnj2.Valor}";
                    else if (jugada is CartaTrampa ctj)
                        detalleCarta += " (Especial)";
                    detalleCarta += "]";
                    string efectoMsg = "";
                    if (jugada is CartaTrampa ctj2 && ctj2.Efectos != null)
                    {
                        foreach (var efecto in ctj2.Efectos)
                        {
                            if (efecto is SaltarTurno)
                            {
                                saltarTurno = sentidoHorario
                                    ? (i + paso) % jugadoresCount
                                    : (i + paso + jugadoresCount) % jugadoresCount;
                                efectoMsg += $" | Efecto: Salta el siguiente turno (aplicado en turno {turno + 1})";
                                efectoAplicado = true;
                            }
                            else if (efecto is GirarSentido)
                            {
                                sentidoHorario = !sentidoHorario;
                                paso = sentidoHorario ? 1 : -1;
                                efectoMsg += $" | Efecto: Se gira el sentido (aplicado en turno {turno + 1})";
                                efectoAplicado = true;
                            }
                            else if (efecto is TomarCarta tomar)
                            {
                                int siguienteIdx = sentidoHorario
                                    ? (i + paso) % jugadoresCount
                                    : (i + paso + jugadoresCount) % jugadoresCount;
                                var cantidadObj = tomar.GetType().GetField("_cantidadARobar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(tomar);
                                int cantidad = cantidadObj is int val ? val : 1;
                                for (int t = 0; t < cantidad; t++)
                                {
                                    var cartaExtra = deckUno.TomarCarta();
                                    if (cartaExtra != null)
                                        jugadoresUno[siguienteIdx].RecibirCarta(cartaExtra);
                                }
                                efectoMsg += $" | Efecto: El siguiente jugador toma {cantidad} carta(s) (aplicado en turno {turno + 1})";
                                efectoAplicado = true;
                            }
                            else if (efecto is CambiarColor)
                            {
                                var coloresValidos = new List<Colores> { Colores.Rojo, Colores.Azul, Colores.Verde, Colores.Amarillo };
                                var rnd = new Random();
                                var nuevoColor = coloresValidos[rnd.Next(coloresValidos.Count)];
                                jugada.Color = nuevoColor;
                                efectoMsg += $" | Efecto: Se cambia el color a {nuevoColor} (aplicado en turno {turno + 1})";
                                efectoAplicado = true;
                            }
                        }
                    }
                    accion = $"jugó {detalleCarta} (mano: {jugador.Mano.CantidadCartas} cartas){efectoMsg}";
                    if (jugador.Mano.CantidadCartas == 1)
                        accion += $" ¡{jugador.Nombre} grita UNO!";
                    if (jugador.Mano.CantidadCartas == 0)
                    {
                        Console.WriteLine($"- {jugador.Nombre}: {accion}");
                        Console.WriteLine($"\n¡{jugador.Nombre} ha ganado el juego de UNO!");
                        juegoTerminado = true;
                        break;
                    }
                }
                else
                {
                    if (deckUno.Cartas.Count == 0)
                    {
                        var cartasParaBarajar = descarte.Take(descarte.Count - 1).ToList();
                        descarte = new List<CartaUnoAbstracta> { descarte.Last() };
                        var rnd = new Random();
                        cartasParaBarajar = cartasParaBarajar.OrderBy(x => rnd.Next()).ToList();
                        foreach (var c in cartasParaBarajar)
                            deckUno.AgregarCarta(c);
                    }
                    var cartaRobada = deckUno.TomarCarta();
                    if (cartaRobada != null)
                        jugador.RecibirCarta(cartaRobada);
                    accion = $"robó o no jugó (mano: {jugador.Mano.CantidadCartas} cartas)";
                }
                Console.WriteLine($"- {jugador.Nombre}: {accion}");
                i += paso;
                if (i >= jugadoresCount) i = 0;
                if (i < 0) i = jugadoresCount - 1;
                procesados++;
            }
            turno++;
        }
        Console.WriteLine("Simulación Uno finalizada.");
    }

    static void SimularBlackjack()
    {
        Console.WriteLine("\nConfigurando simulación de Blackjack...\n");
        var jugadores = new List<IJugadores<ICartaJack>>
        {
            new JugadorCauteloso("Ana Cautelosa", 17),
            new JugadorCauteloso("Bob Conservador", 15),
            new JugadorCauteloso("Diana Equilibrada", 18),
            new JugadorTemerarioJack("Carlos Temerario") as IJugadores<ICartaJack>
        };
        var dealer = new JugadorCauteloso("Dealer", 17);
        jugadores.Add(dealer);
        var deck = DeckJack.ConstruirMazoCompleto();
        var victorias = new Dictionary<string, int>();
        foreach (var jugador in jugadores)
        {
            victorias[jugador.Nombre] = 0;
        }
        int rondas = 5;
        Console.WriteLine("INICIANDO JUEGO: BLACKJACK 21");
        Console.Write("Jugadores: ");
        Console.WriteLine(string.Join(", ", jugadores.ConvertAll(j => j.Nombre)));
        Console.WriteLine($"Se jugarán {rondas} rondas\n");
        for (int ronda = 1; ronda <= rondas; ronda++)
        {
            Console.WriteLine($"\n--- Ronda {ronda} ---");
            var deckRonda = DeckJack.ConstruirMazoCompleto();
            foreach (var jugador in jugadores)
            {
                jugador.Mano.Limpiar();
            }
            dealer.Mano.Limpiar();
            var repartirCartas = new RepartirCartasJack(deckRonda);
            repartirCartas.RepartirCartas(jugadores, dealer);

            foreach (var jugador in jugadores)
            {
                if (jugador == dealer) continue;
                while (true)
                {
                    int puntos = (jugador.Mano as ManoJack)?.CalcularPuntos() ?? 0;
                    if (puntos > 21) break;
                    bool pedirCarta = false;
                    if (jugador is JugadorCauteloso cauteloso)
                    {
                        pedirCarta = puntos < cauteloso.PuntoCorte;
                    }
                    else if (jugador is JugadorTemerario)
                    {
                        pedirCarta = puntos < 21;
                    }
                    if (pedirCarta)
                    {
                        repartirCartas.RepartirCarta(jugador);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            while (true)
            {
                int puntosDealer = (dealer.Mano as ManoJack)?.CalcularPuntos() ?? 0;
                if (puntosDealer >= 17 || puntosDealer > 21) break;
                repartirCartas.RepartirCarta(dealer);
            }

            int puntosDealerFinal = (dealer.Mano as ManoJack)?.CalcularPuntos() ?? 0;
            if (puntosDealerFinal > 21)
            {
                Console.WriteLine("Dealer se pasó, todos los jugadores ganan.");
                foreach (var jugador in jugadores)
                {
                    if (jugador == dealer) continue;
                    int puntosJugador = (jugador.Mano as ManoJack)?.CalcularPuntos() ?? 0;
                    if (puntosJugador <= 21)
                        victorias[jugador.Nombre]++;
                }
            }
            else if (puntosDealerFinal == 21)
            {
                Console.WriteLine("Dealer sacó 21, todos los jugadores pierden la ronda.");
                victorias[dealer.Nombre]++;
            }
            else
            {
                foreach (var jugador in jugadores)
                {
                    if (jugador == dealer) continue;
                    int puntosJugador = (jugador.Mano as ManoJack)?.CalcularPuntos() ?? 0;
                    if (puntosJugador > 21) continue;
                    if (puntosJugador > puntosDealerFinal)
                        victorias[jugador.Nombre]++;
                }
            }

            Console.WriteLine("Resultados de la ronda:");
            var ganadoresRonda = new List<string>();
            foreach (var jugador in jugadores)
            {
                if (jugador == dealer) continue;
                int puntos = (jugador.Mano as ManoJack)?.CalcularPuntos() ?? 0;
                var mano = jugador.Mano as ManoJack;
                string cartasInfo = mano != null ? string.Join(", ", mano.Cartas.Select(c => $"[{c.Valor} de {c.Figura} ({c.Color})]") ) : "";
                Console.WriteLine($"{jugador.Nombre}: {jugador.Mano.CantidadCartas} cartas, {puntos} puntos | Cartas: {cartasInfo}");
                if (puntos <= 21 && (puntosDealerFinal > 21 || puntos > puntosDealerFinal))
                {
                    ganadoresRonda.Add(jugador.Nombre);
                }
            }
            var manoDealer = dealer.Mano as ManoJack;
            string cartasDealerInfo = manoDealer != null ? string.Join(", ", manoDealer.Cartas.Select(c => $"[{c.Valor} de {c.Figura} ({c.Color})]") ) : "";
            Console.WriteLine($"Dealer: {dealer.Mano.CantidadCartas} cartas, {puntosDealerFinal} puntos | Cartas: {cartasDealerInfo}");

            if (ganadoresRonda.Count == 0)
                Console.WriteLine("Nadie ganó la ronda.");
            else
                Console.WriteLine($"Ganador(es) de la ronda: {string.Join(", ", ganadoresRonda)}");
        }

        Console.WriteLine("\n=== RESULTADOS FINALES ===");
        int maxVictorias = victorias.Values.Max();
        var ganadores = victorias.Where(kv => kv.Value == maxVictorias && kv.Key != "Dealer").Select(kv => kv.Key).ToList();
        foreach (var jugador in jugadores)
        {
            if (jugador.Nombre != "Dealer")
                Console.WriteLine($"{jugador.Nombre}: {victorias[jugador.Nombre]} victorias");
        }
        Console.WriteLine("Ganador(es): " + string.Join(", ", ganadores));
    }
}