using DvdStore.Communication.Responses.City;

namespace DvdStore.Communication.Responses.Address;

public class ResponseAddressJson
{
    public int AddressId { get; set; }
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string LastUpdate { get; set; } = string.Empty;
    public int CityId { get; set; }
    public ResponseCityJson City { get; set; } = null!;
}
