using NutriMar.Entidades;
using NutriMar.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NutriMar.Menu
{
  public class MenuCliente
  {
    private static List<Cliente> _lstClientes = new List<Cliente>();
    public static void Menu(List<Cliente> clientes)
    {
      _lstClientes = clientes;

      string op = string.Empty;
      do
      {
        Console.Clear();

        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine("\t\t " + Resources.MenuPrincipalOpcaoClientes);
        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine("[ 1 ] - " + Resources.MenuAdicionar);
        Console.WriteLine("[ 2 ] - " + Resources.MenuClientesListar);
        Console.WriteLine("[ 3 ] - " + Resources.MenuVoltar);
        Console.WriteLine(Resources.BarraMenus);
        Console.Write(Resources.MsgMenuSelecionarOpcao + " ");

        op = Console.ReadLine();
        switch (op)
        {
          case "1":
            _AdicionarCliente();
            break;
          case "2":
            _ListarClientes();
            break;
          case "3":
            break;
          default:
            break;
        }

      } while (op != "3");
    }

    private static void _ListarClientes()
    {
      Console.Clear();

      if (_lstClientes.Count() == 0)
      {
        Console.Write(Resources.MsgClientesNenhumCliente);
      }
      else
      {
        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine(Resources.TituloClientesListagem);
        Console.WriteLine(Resources.BarraMenus);
        Console.WriteLine();
        foreach (var item in _lstClientes)
        {
          _ExibirCliente(item);
        }
      }
      Console.WriteLine(Resources.MsgPressioneTeclaPVoltar);
      Console.ReadLine();
    }

    private static void _AdicionarCliente()
    {
      Console.Clear();

      Cliente cliente = new Cliente();
      cliente.Codigo = _lstClientes.Count() > 0 ? _lstClientes.Max(item => item.Codigo) + 1 : 1;

      Console.WriteLine(Resources.MsgClientesPreencherInform);
      Console.Write("[ 1 ] - " + Resources.ClienteNome + " ");
      cliente.Nome = Console.ReadLine();
      Console.Write("[ 2 ] - " + Resources.ClienteEndereco + " ");
      cliente.Endereco = Console.ReadLine();
      Console.Write("[ 3 ] - " + Resources.ClienteTelefone + " ");
      cliente.AdicionarTelefone(Console.ReadLine());
      string novoTelefone = "s";
      do
      {
        Console.WriteLine(Resources.MsgClientesAdicionarNovoTel);
        novoTelefone = Console.ReadLine();
        if (novoTelefone == "s")
        {
          Console.Write("[ 3 ] - " + Resources.ClienteTelefone + " ");
          cliente.AdicionarTelefone(Console.ReadLine());
        }
      } while (novoTelefone == "s");

      Console.Write("[ 4 ] - " + Resources.ClienteEmail + " ");
      cliente.Email = Console.ReadLine();
      Console.Write("[ 5 ] - " + Resources.ClienteDataNascimento + " ");
      cliente.DataNascimento = Convert.ToDateTime(Console.ReadLine());
      _lstClientes.Add(cliente);

      _ExibirCliente(cliente);
      Console.WriteLine(Resources.MsgPressioneTeclaPVoltar);
      Console.ReadLine();

    }

    private static void _ExibirCliente(Cliente cliente)
    {
      Console.WriteLine();
      Console.WriteLine(Resources.ClienteNome + "[ " + cliente.Codigo +" ] - " + cliente.Nome);
      Console.WriteLine(Resources.ClienteEndereco + cliente.Endereco);
      _ExibirTelefones(cliente.Telefones);
      Console.WriteLine(Resources.ClienteEmail + cliente.Email);
      Console.WriteLine(Resources.ClienteDataNascimento + String.Format("{0:d/M/yyyy}", cliente.DataNascimento));
      Console.WriteLine(Resources.BarraDivisaoEntreObjetos);

    }

    private static void _ExibirTelefones(List<string> telefones)
    {
      if (telefones.Count() > 0)
      {
        if (telefones.Count() == 1)
        {
          telefones.ForEach(item => Console.WriteLine(Resources.ClienteTelefone + item));
        }
        else
        {
          Console.WriteLine(Resources.ClienteTelefones);
          Console.WriteLine("[");
          telefones.ForEach(item => Console.WriteLine(item));
          Console.WriteLine("]");

        }
      }
      else
      {
        Console.WriteLine(Resources.ClienteTelefone);
      }
    }
  }
}
