using NutriMar.Menu;


namespace NutriMar
{
  public class Programa
  {
    static void Main(string[] args)
    {
      bool showMenu = true;
      while (showMenu)
      {
        showMenu = MenuPrincipal.MainMenu();
      }
    }
  }
}
