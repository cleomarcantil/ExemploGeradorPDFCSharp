
namespace Dados;

public class DadosRelatoriosPessoas
{
	public string Titulo => "Relatório - Lista de pessoas";

	public Pessoa[] Registros { get; } = new[]
	{
		new Pessoa { Id = 1, Nome = "Eu", Profissao = "Dev" },
		new Pessoa { Id = 2, Nome = "Fulano", Profissao = "QA" },
		new Pessoa { Id = 3, Nome = "Beltrano", Profissao = "Dev" },
	};

}

public class Pessoa
{
	public int Id { get; set; }
	public required string Nome { get; set; }
	public required string Profissao { get; set; }
}