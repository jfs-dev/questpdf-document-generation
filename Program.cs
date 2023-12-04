using QuestPDF.Infrastructure;
using questpdf_document_generation.Services;

QuestPDF.Settings.License = LicenseType.Community;

var filePath = "Data/QuestPDF.pdf";

QuestPdfService.GeneratePDF(filePath);

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine($"Documento PDF '{ filePath }' gerado com sucesso!");
