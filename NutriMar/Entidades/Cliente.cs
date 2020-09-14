using System;
using System.Collections.Generic;

namespace NutriMar.Entidades
{
  public class Cliente
  {
    public Cliente()
    {
      this.Consultas = new List<Consulta>();
      this.Telefones = new List<string>();
    }
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public List<string> Telefones { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public List<Consulta> Consultas { get; set; }


    public void AdicionarTelefone(string telefone)
    {
      this.Telefones.Add(telefone);
    }

    public void AdicionarConsulta(Consulta consulta)
    {
      this.Consultas.Add(consulta);
    }
  }
}
