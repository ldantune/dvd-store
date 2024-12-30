namespace DvdStore.Domain.Entities;

public class Address
{
    public int AddressId { get; set; }
    public string ?Address1 { get; set; } 
    public string ?Address2 { get; set; } 
    public string ?District { get; set; } 
    public string ?PostalCode { get; set; }
    public string ?Phone { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
    public int CityId { get; set; }
    public City City { get; set; } = null!;
}
