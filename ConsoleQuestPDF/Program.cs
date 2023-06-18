using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// code in your main method
Document.Create(document =>
{
    document.Page(page =>
    {
        page.Margin(30);

        
        page.Header().ShowOnce().Row(row =>
        {
            row.ConstantItem(140).Height(60).Placeholder();

            row.RelativeItem().Column(col =>
            {
                col.Item().AlignCenter().Text("Del Caribe Meat").Bold().FontSize(14);
                col.Item().AlignCenter().Text("1212 Brook Ave, Bronx, NY 10456, Estados Unidos").FontSize(9);
                col.Item().AlignCenter().Text("+1 718-975-0208").FontSize(9);
                col.Item().AlignCenter().Text("delcaribemeat@gmail.com").FontSize(9);
            });

            row.RelativeItem().Column(col =>
            {
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("Item Number").Bold();
                col.Item().Background("#257272").Border(1).BorderColor("#257272").AlignCenter().Text("Product").FontColor("#fff");
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("Quantity");
            });
        });


        //Content
        page.Content().PaddingVertical(10).Column(col =>
        {
            col.Item().Column(col2 =>
            {
                col2.Item().Text("Datos del Producto").Underline().Bold();
                col2.Item().Text(t =>
                {
                    t.Span("Nombre: ").SemiBold().FontSize(10);
                    t.Span("Salami Induveca").FontSize(10);
                });

                col2.Item().Text(t =>
                {
                    t.Span("Descripcion: ").SemiBold().FontSize(10);
                    t.Span("Chuleta").FontSize(10);
                });

                col2.Item().Text(t =>
                {
                    t.Span("Fecha: ").SemiBold().FontSize(10);
                    t.Span("17/06/2023").FontSize(10);
                });
            });

            col.Item().LineHorizontal(0.5f);

            col.Item().Table(tabla =>
            {
                tabla.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                tabla.Header(header =>
                {
                    header.Cell().Background("#257272").Padding(2).Text("Producto").FontColor("#fff");

                    header.Cell().Background("#257272").Padding(2).Text("Precio").FontColor("#fff");

                    header.Cell().Background("#257272").Padding(2).Text("Cantidad").FontColor("#fff");

                    header.Cell().Background("#257272").Padding(2).Text("Total").FontColor("#fff");
                });

                foreach (var item in Enumerable.Range(1,45))
                {
                    var cantidad = Placeholders.Random.Next(1, 10);
                    var precio = Placeholders.Random.Next(5, 15);
                    var total = cantidad * precio;


                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(Placeholders.Label()).FontSize(10);

                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(cantidad.ToString()).FontSize(10);

                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"${precio}").FontSize(10);

                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignRight().Text($"${total}").FontSize(10);
                }
            });

            col.Item().AlignRight().Text("Total: 1500").FontSize(12);

            col.Item().Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Item().Text("Comentarios").FontSize(14);
                column.Item().Text(Placeholders.LoremIpsum());
                column.Spacing(5);
            });

            col.Spacing(10);
        });


        //Footer
        page.Footer().AlignRight().Text(t =>
        {
            t.Span("Pagina ").FontSize(10);
            t.CurrentPageNumber().FontSize(10);
            t.Span(" de ").FontSize(10);
            t.TotalPages().FontSize(10);
        });
    });
}).ShowInPreviewer();

