namespace DvdStore.Domain.Entities;

public class City
{
    public int CityId { get; set; }
    public string ?CityName { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
}
