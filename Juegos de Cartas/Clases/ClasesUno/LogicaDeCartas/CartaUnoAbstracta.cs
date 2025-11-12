using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public abstract class CartaUnoAbstracta : ICarta<int>
{
    private int _valor;
  public virtual int Valor
  {
    get { return _valor; }
    init
    {
      if (value < 0)
      {
        throw new Exception("El valor de la carta no puede ser menor a 0");
      }
      if (value > 9)
      {
        throw new Exception("El valor maximo que puede tomar la carta es 9");
      }
      _valor = value;
    }
  }
  private Colores _color;
  public Colores Color
  {
    get { return _color; }
    init { _color = value; }
  }
  public CartaUnoAbstracta(int valor, Colores color)
  {
    Valor = valor;
    Color = color;
  }
}
