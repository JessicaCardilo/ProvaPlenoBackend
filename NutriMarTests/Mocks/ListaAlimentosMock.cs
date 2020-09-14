using NutriMar.Entidades;
using NutriMar.Enum;
using System.Collections.Generic;

namespace NutriMarTests.Mocks
{
  public class ListaAlimentosMock
  {
    public void PreencheComTodosGrupos(List<Alimento> alimentos)
    {
      alimentos.Add(new Alimento()
      {
        Nome = "Cenoura",
        Calorias = 50,
        Grupo = GrupoAlimentar.GrupoUm
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Batata",
        Calorias = 200,
        Grupo = GrupoAlimentar.GrupoUm
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Inhame",
        Calorias = 150,
        Grupo = GrupoAlimentar.GrupoUm
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Frango",
        Calorias = 250,
        Grupo = GrupoAlimentar.GrupoDois
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Bife Bovino",
        Calorias = 350,
        Grupo = GrupoAlimentar.GrupoDois
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Ovo",
        Calorias = 65,
        Grupo = GrupoAlimentar.GrupoDois
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Alface",
        Calorias = 12,
        Grupo = GrupoAlimentar.GrupoTres
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Couve",
        Calorias = 15,
        Grupo = GrupoAlimentar.GrupoTres
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Brocolis",
        Calorias = 23,
        Grupo = GrupoAlimentar.GrupoTres
      });
    }

    public void PreencheFaltandoGrupo(List<Alimento> alimentos)
    {
      alimentos.Add(new Alimento()
      {
        Nome = "Cenoura",
        Calorias = 50,
        Grupo = GrupoAlimentar.GrupoUm
      });
      alimentos.Add(new Alimento()
      {
        Nome = "Rucula",
        Calorias = 200,
        Grupo = GrupoAlimentar.GrupoDois
      });
    }
  }
}
