using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases;
using System.Linq;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;


public class ManoJack : Mano<ICartaJack>
{
    private readonly IPuntosJack _puntosJack;
    private readonly IEstadosJack _estadosJack;
    private readonly IResetMano _resetMano;

    public ManoJack(IPuntosJack puntosJack, IEstadosJack estadosJack, IResetMano resetMano)
    {
        _puntosJack = puntosJack ?? throw new ArgumentNullException(nameof(puntosJack));
        _estadosJack = estadosJack ?? throw new ArgumentNullException(nameof(estadosJack));
        _resetMano = resetMano ?? throw new ArgumentNullException(nameof(resetMano));
    }


    public int CalcularPuntos()
    {
        return _puntosJack.CalcularPuntos(Cartas);
    }
    public bool EsBlackjack()
    {
        return _estadosJack.EsBlackjack(Cartas, CantidadCartas);
    }
    public bool SePaso()
    {
        return _estadosJack.SePaso(Cartas);
    }
    public string ObtenerDescripcionCompleta()
    {
    return _resetMano.FormatearDescripcionCompleta(Cartas);
    }

}
