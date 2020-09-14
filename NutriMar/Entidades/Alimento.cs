using NutriMar.Enum;

namespace NutriMar.Entidades
{
  public class Alimento
  {
    public string Nome { get; set; }
    public double Calorias { get; set; }
    public GrupoAlimentar Grupo { get; set; }
  }
}
