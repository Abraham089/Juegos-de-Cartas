using System;
using Juegos_de_Cartas.Interfaces;
using Juegos_de_Cartas.Clases.Enumeradores;

namespace Juegos_de_Cartas.Clases.ClasesUno;

public class CartaTrampa : CartaUnoAbstracta
{
  private readonly List<IEfectoDeCarta> _efectos;
  public IReadOnlyList<IEfectoDeCarta> Efectos
  {
    get { return _efectos; }
    init
    {
      if (value.Count is 0)
      {
        throw new Exception("La carta trampa debe de tener un efecto");
      }
      _efectos = (List<IEfectoDeCarta>)value;
    }
  }
  public CartaTrampa(int valor, Colores color, List<IEfectoDeCarta> efectos) : base(valor, color)
  {
    Efectos = efectos;
  }
}
