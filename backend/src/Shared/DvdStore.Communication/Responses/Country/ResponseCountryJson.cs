using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DvdStore.Communication.Responses.Country;

public class ResponseCountryJson
{
    public int CountryId { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public string LastUpdate { get; set; } = string.Empty;
}
