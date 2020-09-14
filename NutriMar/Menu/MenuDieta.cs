using NutriMar.Entidades;
using NutriMar.Enum;
using NutriMar.Properties;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NutriMar.Menu
{
  public class MenuDieta
  {
    private static List<Alimento> _lstAlimentos;
    private static Dieta _dieta;
    public static void Menu()
    {
      Console.Clear();
      _dieta = new Dieta();
      _lstAlimentos = new List<Alimento>();

      Console.WriteLine(Resources.BarraMenus);
      Console.WriteLine("\t\t " + Resources.TituloMenuDieta);
      Console.WriteLine(Resources.BarraMenus);
      Console.WriteLine(Resources.MsgDietaPreencherInfo);

      _lstAlimentos.Add(_AdicionarAlimento());
      _ContinuarAdicionando();

      Console.WriteLine(Resources.MsgPressioneTelcaParaSair);
      Console.ReadLine();

    }

    private static void _ContinuarAdicionando()
    {
      var novoAlimento = "s";
      do
      {
        Console.WriteLine(Resources.MsgDietaNovoAlimento + " ");
        novoAlimento = Console.ReadLine();
        if (novoAlimento == "s")
        {
          _lstAlimentos.Add(_AdicionarAlimento());
        }
      } while (novoAlimento == "s");


      if (!_dieta.ContemTodosGruposAlimentos(_lstAlimentos))
      {
        Console.WriteLine(Resources.MsgDietaNaoContemTodosGrupos + " ");
        if (Console.ReadLine() == "s")
        {
          _ContinuarAdicionando();
        }
      }
      else
      {
        _MontaDieta();
      }
    }

    private static void _MontaDieta()
    {
      Console.Write(Resources.MsgDietaInformeMeta + " ");
      double meta = Convert.ToDouble(Console.ReadLine());
      Console.WriteLine(Resources.MsgDietaCombinacoesPossiveis,  meta);
      Console.WriteLine();

      var combinacoes = _dieta.GerarCombinacoes(meta, _lstAlimentos);

      if (combinacoes.Count() == 0)
      {
        Console.WriteLine(Resources.MsgDietaSemCombinacoes);
      }
      else
      {
        _ExibirCombinacoes(combinacoes);

      }
      var novaMeta = "s";
      do
      {
        Console.Write(Resources.MsgDietaPerguntaNovaMeta + " ");
        novaMeta = Console.ReadLine();
        if (novaMeta == "s")
        {
          Console.WriteLine(Resources.MsgDietaInformeNovaMeta);
          meta = Convert.ToDouble(Console.ReadLine());

          Console.WriteLine(Resources.MsgDietaCombinacoesPossiveis, meta);
          Console.WriteLine();

          _ExibirCombinacoes(_dieta.GerarCombinacoes(meta, _lstAlimentos));

          if (_dieta.GerarCombinacoes(meta, _lstAlimentos).Count() == 0)
          {
            Console.WriteLine(Resources.MsgDietaSemCombinacoes);
          }
        }
      } while (novaMeta == "s");
    }

    private static void _ExibirCombinacoes(List<string> combinacoes)
    {
      Console.WriteLine(Resources.BarraDietaExibirCombinacoes);

      foreach (var item in combinacoes)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine(Resources.BarraDietaExibirCombinacoes);
    }

    private static Alimento _AdicionarAlimento()
    {
      Alimento alimento = new Alimento();

      Console.WriteLine();
      Console.Write(Resources.AlimentoNome + " ");
      alimento.Nome = Console.ReadLine();
      Console.Write(Resources.AlimentoValorCalorico + " ");
      alimento.Calorias = Convert.ToDouble(Console.ReadLine());
      Console.Write(Resources.AlimentoGrupo + " ");
      alimento.Grupo = (GrupoAlimentar)Convert.ToInt32(Console.ReadLine());
      Console.WriteLine(Resources.BarraDivisaoEntreObjetos);

      return alimento;
    }
  }
}
