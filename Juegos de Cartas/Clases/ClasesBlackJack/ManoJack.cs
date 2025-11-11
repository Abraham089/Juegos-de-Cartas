using System;
using System.Collections.Generic;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases;
using System.Linq;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;


public class ManoJack : Mano<ICartaJack>
{
    private IPuntosJack? _puntosJack;

    public IPuntosJack? PuntosJack
    {
        get { return _puntosJack; }
        private set
        {
            if (value == null)
            {
                throw new Exception("PuntosJack no puede ser null");
            }
            _puntosJack = value;
        }
    }

    private IEstadosJack? _estadosJack;
    public IEstadosJack? EstadosJack
    {
        get { return _estadosJack; }
        private set
        {
            if (value == null)
            {
                throw new Exception("EstadosJack no puede ser null");
            }
            _estadosJack = value;
        }
    }

    private IResetMano?  _resetMano;
        public IResetMano?  ResetMano
        {
            get { return _resetMano; }
            private set
            {
                if (value == null)
                {
                    throw new Exception("ResetMano no puede ser null");
                }
                _resetMano = value;
            }
        }

    public ManoJack(IPuntosJack? puntosJack, IEstadosJack? estadosJack, IResetMano? resetMano)
    {

    PuntosJack = puntosJack;
    EstadosJack = estadosJack;
    ResetMano = resetMano;

    }


    public int CalcularPuntos()
    {
        return _puntosJack!.CalcularPuntos(Cartas);
    }
    public bool EsBlackjack()
    {
        return _estadosJack!.EsBlackjack(Cartas, CantidadCartas);
    }
    public bool SePaso()
    {
        return _estadosJack!.SePaso(Cartas);
    }
    public string ObtenerDescripcionCompleta()
    {
    return _resetMano!.FormatearDescripcionCompleta(Cartas);
    }

}
