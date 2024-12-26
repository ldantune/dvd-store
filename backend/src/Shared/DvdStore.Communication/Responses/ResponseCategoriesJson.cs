namespace DvdStore.Communication.Responses;
public class ResponseCategoriesJson
{
    public IList<ResponseCategoryJson> Categories { get; set; } = [];
    public int TotalItems { get; set; } // Total de itens disponíveis
    public int PageNumber { get; set; } // Página atual
    public int PageSize { get; set; }   // Tamanho da página
}
