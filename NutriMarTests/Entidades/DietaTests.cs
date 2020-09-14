using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutriMar.Entidades;
using NutriMarTests.Mocks;
using System.Collections.Generic;
using System.Linq;


namespace NutriMar.Tests
{
  [TestClass]
  public class DietaTests
  {
    private ListaAlimentosMock _lstAlimentosMock;
    private List<Alimento> _alimentos;

    [TestInitialize]
    public void TestInitialize()
    {
      _lstAlimentosMock = new ListaAlimentosMock();
      _alimentos = new List<Alimento>();
    }

    [TestMethod]
    public void GerarCombinacoesComListaPreenchidaTest()
    {
      Dieta dieta = new Dieta();

      _lstAlimentosMock.PreencheComTodosGrupos(_alimentos);

      var resultado = dieta.GerarCombinacoes(400, _alimentos);

      Assert.AreEqual(12, resultado.Count());
    }

    [TestMethod]
    public void GerarCombinacoesComListaVaziaTest()
    {
      Dieta dieta = new Dieta();

      var resultado = dieta.GerarCombinacoes(400, _alimentos);

      Assert.AreEqual(0, resultado.Count());
    }

    [TestMethod]
    public void Retorna_Verdadeiro_Quando_ContemTodosGruposAlimentosQTest()
    {
      Dieta dieta = new Dieta();

      _lstAlimentosMock.PreencheComTodosGrupos(_alimentos);

      var resultado = dieta.ContemTodosGruposAlimentos(_alimentos);

      Assert.AreEqual(true, resultado);
    }

    [TestMethod]
    public void Retorna_Falso_Quando_Nao_ContemTodosGruposAlimentosTest()
    {
      Dieta dieta = new Dieta();

      _lstAlimentosMock.PreencheFaltandoGrupo(_alimentos);

      var resultado = dieta.ContemTodosGruposAlimentos(_alimentos);

      Assert.AreEqual(false, resultado);
    }
  }
}