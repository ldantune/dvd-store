namespace DvdStore.Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string ?FirstName { get; set; }
    public string ?LastName { get; set; }
    public string ?Email { get; set; }
    public bool Activebool { get; set; } 
    public string CreateDate { get; set; } = string.Empty;
    public string LastUpdate { get; set; } = string.Empty;
    public int Active { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
}
