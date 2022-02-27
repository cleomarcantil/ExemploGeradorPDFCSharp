using Dados;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ExenploGeradorPDFCSharp.GeraPDF;

public class GeraRelatorioPessoasPDF : IDocument
{
	private readonly DadosRelatoriosPessoas dadosRelatoriosPessoas;

	public GeraRelatorioPessoasPDF(DadosRelatoriosPessoas dadosRelatoriosPessoas)
	{
		this.dadosRelatoriosPessoas = dadosRelatoriosPessoas;
	}

	public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

	public void Compose(IDocumentContainer container)
	{
        container
             .Page(page =>
             {
                 page.Margin(15, Unit.Millimetre);

                 page.Header().Element(ComposeHeader);

                 page.Content().Element(ComposeContent);

                 page.Footer().Element(ComposeFooter);
             });
    }


    private void ComposeHeader(IContainer container)
    {
        var titleStyle = TextStyle.Default.Size(16).SemiBold().Color(Colors.Blue.Medium);

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text(dadosRelatoriosPessoas.Titulo, titleStyle);

                column.Item().Text(text =>
                {
                    text.Span("Data: ", TextStyle.Default.SemiBold());
                    text.Span($"{DateTime.Now:d}");
                });

                column.Item().Text(text =>
                {
                    text.Span("Hora: ", TextStyle.Default.SemiBold());
                    text.Span($"{DateTime.Now:T}");
                });
            });

            //row.ConstantItem(100).Height(50).Placeholder();
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.PaddingVertical(40).Column(column =>
        {
            column.Spacing(5);

            column.Item().Element(ComposeTable);
        });
    }

    private void ComposeTable(IContainer container)
    {
        var headerStyle = TextStyle.Default.SemiBold();

        container.Table(table =>
        {
            // step 1
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(25);
                columns.RelativeColumn(3);
                columns.RelativeColumn();
            });

            // step 2
            table.Header(header =>
            {
                header.Cell().Text("Id", headerStyle);
                header.Cell().Text("Nome", headerStyle);
                header.Cell().AlignRight().Text("Profissão", headerStyle);

                header.Cell().ColumnSpan(3)
                    .PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
            });

            // step 3
            foreach (var p in dadosRelatoriosPessoas.Registros)
            {
                table.Cell().Element(CellStyle).Text(p.Id);
                table.Cell().Element(CellStyle).Text(p.Nome);
                table.Cell().Element(CellStyle).AlignRight().Text(p.Profissao);

                static IContainer CellStyle(IContainer container) =>
                    container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
            }
        });
    }

    private void ComposeFooter(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text($"{dadosRelatoriosPessoas.Registros.Length} Pessoas");
            });
        });
	}

}
