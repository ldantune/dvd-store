using DvdStore.Communication.Responses.Film;
using DvdStore.Communication.Responses.Store;

namespace DvdStore.Communication.Responses.Inventory;

public class ResponseInventoryJson
{
    public int InventoryId { get; set; }
    public int FilmId { get; set; }
    public int StoreId { get; set; }
    public ResponseStoreJson Store { get; set; } = null!;
    public string LastUpdate { get; set; } = string.Empty;
    public ResponseFilmJson Film { get; set; } = null!;
}
