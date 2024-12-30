using DvdStore.Communication.Responses.Inventory;

namespace DvdStore.Communication.Responses.Rental;

public class ResponseRentalJson
{
    public int RentalId { get; set; }
    public string RentalDate { get; set; } = string.Empty;
    public int InventoryId { get; set; }
    public ResponseInventoryJson Inventory { get; set; } = null!;
    public int CustomerId { get; set; }
    public string ReturnDate { get; set; } = string.Empty;
    public int StaffId { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
}
