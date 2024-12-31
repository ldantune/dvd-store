namespace DvdStore.Domain.Entities;

public class Inventory
{
    public int InventoryId { get; set; }
    public int FilmId { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public string LastUpdate { get; set; } = string.Empty;
    public Film Film { get; set; } = null!;
}
