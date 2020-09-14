using NutriMar.Entidades;
using NutriMar.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriMar.Menu
{
  public class MenuConsulta
  {
    private static List<Cliente> _lstClientes = new List<Cliente>();
    private static List<Consulta> _lstConsultas = new List<Consulta>();
    public static void Menu(List<Cliente> clientes, List<Consulta> consultas)
    {
      _lstClientes = clientes;
      _lstConsultas = consultas;

      string op = string.Empty;
      do
      {
        Console.Clear();
        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine("\t\t" + Resources.MenuPrincipalOpcaoConsultas);
        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine("[ 1 ] - " + Resources.MenuAdicionar);
        Console.WriteLine("[ 2 ] - " + Resources.MenuConsultasListarTodas);
        Console.WriteLine("[ 3 ] - " + Resources.MenuConsultasListarPorPaciente);
        Console.WriteLine("[ 4 ] - " + Resources.MenuVoltar);
        Console.WriteLine(Resources.BarraMenus);
        Console.Write(Resources.MsgMenuSelecionarOpcao);

        op = Console.ReadLine();
        switch (op)
        {
          case "1":
            _AdicionarConsulta();
            break;
          case "2":
            _ListarConsultas();
            break;
          case "3":
            _ListarConsultasPor();
            break;
          case "4":
            break;
          default:
            break;
        }

      } while (op != "4");
    }

    private static void _ListarConsultasPor()
    {
      Console.Clear();

      Console.WriteLine(Resources.MsgConsultasInformPaciente);
      var codigoPaciente = Convert.ToInt32(Console.ReadLine());

      var consultasPaciente = _lstConsultas.FindAll(item => item.CodigoCliente == codigoPaciente);
      if (consultasPaciente.Count() == 0)
      {
        Console.WriteLine(Resources.MsgConsultasPacienteNExisteConsulta);
      }
      else
      {
        foreach (var item in consultasPaciente)
        {
          _ExibirConsulta(item);
        }
      }

      Console.WriteLine(Resources.MsgPressioneTeclaPVoltar);
      Console.ReadLine();
    }

    private static void _AdicionarConsulta()
    {
      Console.Clear();
      if (_lstClientes.Count() == 0)
      {
        Console.WriteLine(Resources.MsgConsultasCadastroPaciente);
      }
      else
      {
        Consulta consulta = new Consulta();

        consulta.Codigo = _lstConsultas.Count() > 0 ? _lstConsultas.Max(item => item.Codigo) + 1 : 1;

        Console.WriteLine(Resources.MsgConsultasPreenchaInform);
        Console.Write("[ 1 ] - " + Resources.ConsultaNomeCliente + " ");
        var codigoCliente = Console.ReadLine();
        if (_ExisteCliente(codigoCliente) > 0)
        {
          var cliente = _lstClientes?.Find(item => item.Codigo == Convert.ToInt32(codigoCliente));
          consulta.CodigoCliente = cliente.Codigo;
          consulta.NomeCliente = cliente.Nome;
          Console.Write("[ 2 ] - " + Resources.ConsultaData + " ");
          consulta.Data = Convert.ToDateTime(Console.ReadLine());
          Console.Write("[ 3 ] - " + Resources.ConsultaHorario + " ");
          consulta.Horario = Console.ReadLine();
          Console.Write("[ 4 ] - " + Resources.ConsultaPeso + " ");
          consulta.Peso = Convert.ToDouble(Console.ReadLine());
          Console.Write("[ 5 ] - " + Resources.ConsultaPercentGordura + " ");
          consulta.PercentGorduraCorporal = Convert.ToDouble(Console.ReadLine());
          Console.Write("[ 6 ] - " + Resources.ConsultaSensacaoFisica + " ");
          consulta.SensacaoFisica = Console.ReadLine();
          Console.Write("[ 7 ] - " + Resources.ConsultaRestricoes + " ");
          consulta.Restricoes = Console.ReadLine();

          _lstConsultas.Add(consulta);
          cliente.AdicionarConsulta(consulta);

          _ExibirConsulta(consulta);
        }
        else
        {
          Console.WriteLine(Resources.ConsultaPacienteNEncontrado);
        }
      }

      Console.WriteLine(Resources.MsgPressioneTeclaPVoltar);
      Console.ReadLine();
    }

    private static int _ExisteCliente(string codCliente)
    {
      if (!string.IsNullOrEmpty(codCliente))
      {
        var resultado = _lstClientes?.Find(item => item.Codigo == Convert.ToInt32(codCliente));
        if (resultado != null)
        {
          return resultado.Codigo;
        }
      }

      return 0;
    }

    private static void _ExibirConsulta(Consulta consulta)
    {
      Console.WriteLine();
      Console.WriteLine(Resources.ConsultaNomeCliente + "[ " + consulta.CodigoCliente + " ] - " + consulta.NomeCliente);
      Console.WriteLine(Resources.ConsultaData + String.Format("{0:d/M/yyyy}", consulta.Data));
      Console.WriteLine(Resources.ConsultaHorario + consulta.Horario);
      Console.WriteLine(Resources.ConsultaPeso + consulta.Peso);
      Console.WriteLine(Resources.ConsultaPercentGordura + consulta.PercentGorduraCorporal + " %");
      Console.WriteLine(Resources.ConsultaSensacaoFisica + consulta.SensacaoFisica);
      Console.WriteLine(Resources.ConsultaRestricoes + consulta.Restricoes);
      Console.WriteLine(Resources.BarraDivisaoEntreObjetos);

    }

    private static void _ListarConsultas()
    {
      Console.Clear();

      if (_lstConsultas.Count() == 0)
      {
        Console.Write(Resources.MsgConsultasNExiste);
      }
      else
      {
        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine(Resources.MenuConsultasLista);
        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine();
        foreach (var item in _lstConsultas)
        {
          _ExibirConsulta(item);
        }
      }
      Console.WriteLine(Resources.MsgPressioneTeclaPVoltar);
      Console.ReadLine();
    }
  }
}
