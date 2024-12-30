
namespace DvdStore.Communication.Responses.Rental;

public class ResponseRentalsJson
{
    public IList<ResponseRentalJson> Rentals { get; set; } = [];
    public int TotalItems { get; set; } // Total de itens disponíveis
    public int PageNumber { get; set; } // Página atual
    public int PageSize { get; set; }   // Tamanho da página
}
