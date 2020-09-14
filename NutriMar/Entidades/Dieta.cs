using NutriMar.Enum;
using System.Collections.Generic;
using System.Linq;

namespace NutriMar.Entidades
{
  public class Dieta
  {
    public List<string> GerarCombinacoes(double meta, List<Alimento> alimentos)
    {
      List<string> combinacoes = new List<string>();
      List<Alimento> grupoUm = alimentos.FindAll(item => item.Grupo == GrupoAlimentar.GrupoUm);
      List<Alimento> grupoDois = alimentos.FindAll(item => item.Grupo == GrupoAlimentar.GrupoDois);
      List<Alimento> grupoTres = alimentos.FindAll(item => item.Grupo == GrupoAlimentar.GrupoTres);

      foreach (var gpUm in grupoUm)
      {
        foreach (var gpDois in grupoDois)
        {
          foreach (var gpTres in grupoTres)
          {
            var totalCalorias = gpUm.Calorias + gpDois.Calorias + gpTres.Calorias;
            if (totalCalorias <= meta)
            {
              combinacoes.Add("| " + gpUm.Nome + " | + | " + gpDois.Nome + " | + | " + gpTres.Nome + " | - | Total de calorias: " + totalCalorias + "|");
            }
          }
        }
      }
      return combinacoes;
    }

    public bool ContemTodosGruposAlimentos(List<Alimento> lstAlimentos)
    {
      var resultado = from alimento in lstAlimentos
                      group alimento by alimento.Grupo
               into groups
                      select groups.OrderBy(p => p.Grupo).First();

      if (resultado.Count() < 3)
      {
        return false;
      }
      return true;
    }
  }
}
