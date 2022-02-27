using Dados;
using ExemploGeradorPDFCSharp.GeraPDF;
using QuestPDF.Fluent;
using System.Diagnostics;
using System.Runtime.InteropServices;

Console.WriteLine("Exemplo de Geração de PDFs com CSharp usando o pacote QuestPDF.");

Console.WriteLine($"(1) - Gerar relatório de pessoas");

Console.Write($"Escolha uma opção: ");
var opcao = Console.ReadKey();
Console.WriteLine();

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

Console.WriteLine($"Arquivo gerado: '{Path.GetFileName(filePath)}'.");


if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
	Process.Start("explorer.exe", filePath);
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
	Process.Start("xdg-open", filePath);
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
	Process.Start("open", filePath);
