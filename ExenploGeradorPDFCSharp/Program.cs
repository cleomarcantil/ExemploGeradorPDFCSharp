using Dados;
using ExenploGeradorPDFCSharp.GeraPDF;
using QuestPDF.Fluent;
using System.Diagnostics;

Console.WriteLine("Exemplo de Geração de PDFs com CSharp usando o pacote QuestPDF.");

Console.WriteLine($"(1) - Gerar relatório de pessoas");

Console.Write($"Escolha uma opção: ");
var opcao = Console.ReadKey();

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "teste.pdf");

switch (opcao.KeyChar)
{
	case '1':
		var dadosRelatorio = new DadosRelatoriosPessoas();
		var geraPDF = new GeraRelatorioPessoasPDF(dadosRelatorio);
		geraPDF.GeneratePdf(filePath);
		break;

	default:
		Console.WriteLine($"Opção inválida '{opcao}'!");
		return;
}

Process.Start("explorer.exe", filePath);
