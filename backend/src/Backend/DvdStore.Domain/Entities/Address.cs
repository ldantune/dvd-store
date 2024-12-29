namespace DvdStore.Domain.Entities;

public class Address
{
    public int AddressId { get; set; }
    public string Address1 { get; set; } =  string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string LastUpdate { get; set; } = string.Empty;
    public int CityId { get; set; }
    public City City { get; set; } = null!;
}
