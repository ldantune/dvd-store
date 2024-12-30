using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DvdStore.Domain.Entities;

public class Rental
{
    public int RentalId { get; set; }
    public string RentalDate { get; set; } = string.Empty;
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; } = null!;
    public int CustomerId { get; set; }
    public string ReturnDate { get; set; } = string.Empty;
    public int StaffId { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
}
