using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class CartaJack : ICartaJack
{
    public ValoresCartaJack Valor { get; private set; }
    public Figuras Figura { get; private set; }
    public Colores Color { get; private set; }

    public CartaJack(ValoresCartaJack valor, Figuras figura)
    {
        Valor = valor;
        Figura = figura;
        Color = figura == Figuras.Corazones || figura == Figuras.Diamantes ? Colores.Rojo : Colores.Negro;
                 
    }

    public int ObtenerValorNumerico(bool asAsOnce = false)
    {
        if (Valor == ValoresCartaJack.As)
        {
            return asAsOnce ? 1 : 11;
        }
       if (Valor == ValoresCartaJack.Jota|| Valor == ValoresCartaJack.Reina|| Valor == ValoresCartaJack.Rey)
       {
           return 10;
       }
       return (int)Valor;
    }

    public string ObtenerDescripcionDeCarta()
    {
        return $"{Valor} de {Figura} ({Color})";
    }

    public bool EsCartaJugable(ICarta<ValoresCartaJack> carta)
    {
        return carta is CartaJack;
    }
     public override bool Equals(object? obj)
        {
            if (obj is CartaJack otra)
            {
                return Valor == otra.Valor && Figura == otra.Figura;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Valor, Figura);
        }

        public override string ToString()
        {
            return  ObtenerDescripcionDeCarta();
        }
}
