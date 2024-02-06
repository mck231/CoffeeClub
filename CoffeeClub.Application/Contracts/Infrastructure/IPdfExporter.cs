namespace CoffeeClub.Application.Contracts.Infrastructure;

public interface IPdfExporter<in T>
{
    void ExportToPdf(T votes);
}