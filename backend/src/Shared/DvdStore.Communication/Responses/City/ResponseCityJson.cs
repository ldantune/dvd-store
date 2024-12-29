using DvdStore.Communication.Responses.Country;

namespace DvdStore.Communication.Responses.City;

public class ResponseCityJson
{
    public int CityId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string LastUpdate { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public ResponseCountryJson Country { get; set; } = null!;
}
