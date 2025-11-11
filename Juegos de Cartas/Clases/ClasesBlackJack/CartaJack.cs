using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.Enumeradores;
using Juegos_de_Cartas.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesBlackJack;

public class CartaJack : ICartaJack
{
    private ValoresCartaJack _valor;
    public ValoresCartaJack Valor
    {
        get { return _valor; }
        private set
        {
            if (!Enum.IsDefined(typeof(ValoresCartaJack), value))
            {
                throw new Exception(message:"Valor de carta no valido");
            }
            _valor = value;
        }
    }
    private Figuras _figura;
    public Figuras Figura
    {
        get { return _figura; }
        private set
        {
            if (!Enum.IsDefined(typeof(Figuras), value))
            {
                throw new Exception(message:"Figura de carta no valida");
            }
            _figura = value;
        }
    }
    private Colores _color;
    public Colores Color
    {
        get { return _color; }
        private set
        {
            if (!Enum.IsDefined(typeof(Colores), value))
            {
                throw new Exception(message:"Color de carta no valido");
            }
            _color = value;
        }
    }

    public CartaJack(ValoresCartaJack valor, Figuras figura)
    {
        Valor = valor;
        Figura = figura;
       if (figura == Figuras.Corazones || figura == Figuras.Diamantes)
        {
            Color = Colores.Rojo;
        }
        else
        {
            Color = Colores.Negro;
        }
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
