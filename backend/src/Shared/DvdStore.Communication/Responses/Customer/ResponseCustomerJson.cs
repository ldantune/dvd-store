using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdStore.Communication.Responses.Address;
using DvdStore.Communication.Responses.Store;

namespace DvdStore.Communication.Responses.Customer;

public class ResponseCustomerJson
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
    public ResponseStoreJson Store { get; set; } = null!;
    public int AddressId { get; set; }
    public ResponseAddressJson Address { get; set; } = null!;
}
