namespace DvdStore.Communication.Requests;
public class PaginationQuery
{
    public int PageNumber { get; set; } = 1; // Página padrão
    public int PageSize { get; set; } = 10;  // Tamanho padrão
    public bool IsPaged { get; set; } = true;
}
