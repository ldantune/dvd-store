using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DvdStore.Communication.Responses.Customer;

public class ResponseCustomersJson
{
    public IList<ResponseCustomerJson> Customers { get; set; } = [];
    public int TotalItems { get; set; } // Total de itens disponíveis
    public int PageNumber { get; set; } // Página atual
    public int PageSize { get; set; }   // Tamanho da página
}
