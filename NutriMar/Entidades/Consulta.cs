using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriMar.Entidades
{
  public class Consulta
  {
    public int Codigo { get; set; }
    public DateTime Data { get; set; }
    public string Horario { get; set; }
    public int CodigoCliente { get; set; }
    public string NomeCliente { get; set; }
    public double Peso { get; set; }
    public double PercentGorduraCorporal { get; set; }
    public string SensacaoFisica { get; set; }
    public string Restricoes { get; set; }

  }
}
