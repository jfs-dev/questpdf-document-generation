using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace questpdf_document_generation.Services;

public static class QuestPdfService
{
    public static void GeneratePDF(string filePath)
    {
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(14));
                
                page.Header()
                    .Text("Clean Architecture")
                    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);
                
                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);

                        x.Item().Text("Criada por Uncle Bob (Robert C. Martin), é um padrão de arquitetura de software que visa criar sistemas bem estruturados, testáveis e independentes de frameworks, UI (User Interface) e bases de dados. O objetivo é manter o código flexível e adaptável a mudanças, facilitando sua manutenção e evolução ao longo do tempo.");
                        x.Item().Text("Clean Architecture é baseada em princípios sólidos de design de software, como o princípio da separação de preocupações e a dependência de direção única (DIP - Dependency Inversion Principle). Ela propõe a organização do sistema em camadas concêntricas, onde cada camada representa um nível de abstração e possui suas próprias responsabilidades.");
                        x.Item().Text("As camadas comuns na Clean Architecture incluem:");

                        x.Item().Text(text =>
                        {
                            text.Span("1. Entidades:").Bold().Underline();
                            text.Span(" Representam as regras de negócio e são o núcleo da aplicação. São independentes de qualquer detalhe técnico.");
                        });

                        x.Item().Text(text =>
                        {
                            text.Span("2. Casos de Uso (Use Cases):").Bold().Underline();
                            text.Span(" Também conhecidos como Interactors ou Application Layer, essa camada contém a lógica de aplicação. Ela coordena as operações do sistema sem depender de detalhes de implementação.");
                        });

                        x.Item().Text(text =>
                        {
                            text.Span("3. Interfaces de Interface do Usuário (UI):").Bold().Underline();
                            text.Span(" Essa camada lida com a interação do usuário, podendo ser uma interface de linha de comando, interface gráfica ou interface web. É a camada mais externa e depende das camadas internas.");
                        });

                        x.Item().Text(text =>
                        {
                            text.Span("4. Frameworks e Drivers Externos:").Bold().Underline();
                            text.Span(" Inclui frameworks, ferramentas e componentes externos, como bancos de dados, bibliotecas, etc. Essa camada é a mais externa e é responsável por conectar o sistema com o mundo exterior.");
                        });
                        
                        x.Item().Text("Uma das principais vantagens da Clean Architecture é a facilidade de testabilidade, já que as regras de negócio e lógica de aplicação são separadas das camadas externas, o que permite a realização de testes automatizados sem depender de detalhes de implementação.");
                        x.Item().Text("Essa arquitetura promove a manutenção de um código mais limpo, escalável e adaptável a mudanças, pois facilita a identificação e alteração de partes específicas do sistema sem afetar outras áreas.");
                        
                        x.Item().Image(File.ReadAllBytes("Images/CleanArchitecture.jpg"));
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                    });
            });
        })
        .GeneratePdf(filePath);
    }
}