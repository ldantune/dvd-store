using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdStore.Communication.Responses.Address;

namespace DvdStore.Communication.Responses.Store;

public class ResponseStoreJson
{
    public int StoreId { get; set; }
    public int ManagerStaffId { get; set; }
    public int AddressId { get; set; }
    public ResponseAddressJson Address { get; set; } = null!;
    public string LastUpdate { get; set; } = string.Empty;
}
