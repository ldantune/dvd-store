namespace DvdStore.Domain.Entities;

public class Country
{
    public int CountryId { get; set; }
    public string ?CountryName { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
}
