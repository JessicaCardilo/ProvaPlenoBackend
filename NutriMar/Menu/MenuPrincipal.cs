using NutriMar.Entidades;
using NutriMar.Properties;
using System;
using System.Collections.Generic;

namespace NutriMar.Menu
{
  public class MenuPrincipal
  {
    private static List<Cliente> _lstClientes = new List<Cliente>();
    private static List<Consulta> _lstConsultas = new List<Consulta>();
    public static bool MainMenu()
    {
      Console.Clear();
      Console.WriteLine(Resources.BarraMenus);
      Console.WriteLine("\t\t " + Resources.TituloMenuPrincipal);
      Console.WriteLine(Resources.BarraMenus);
      Console.WriteLine("[ 1 ] - " + Resources.MenuPrincipalOpcaoClientes);
      Console.WriteLine("[ 2 ] - " + Resources.MenuPrincipalOpcaoDieta);
      Console.WriteLine("[ 3 ] - " + Resources.MenuPrincipalOpcaoConsultas);
      Console.WriteLine("[ 4 ] - " + Resources.MenuPrincipalOpcaoSair);
      Console.WriteLine(Resources.BarraMenus);
      Console.Write(Resources.MsgMenuSelecionarOpcao);

      switch (Console.ReadLine())
      {
        case "1":
          MenuCliente.Menu(_lstClientes);
          return true;
        case "2":
          MenuDieta.Menu();
          return true;
        case "3":
          MenuConsulta.Menu(_lstClientes, _lstConsultas);
          return true;
        case "4":
          return false;
        default:
          return true;
      }
    }
  }
}
