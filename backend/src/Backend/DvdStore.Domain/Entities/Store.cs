namespace DvdStore.Domain.Entities;

public class Store
{
    public int StoreId { get; set; }
    public int ManagerStaffId { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
    public string LastUpdate { get; set; } = string.Empty;
}
