using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdStore.Communication.Responses.Customer;

namespace DvdStore.Application.UseCases.Customers.Get;

public interface IGetCustomersUseCase
{
    Task<ResponseCustomersJson> ExecuteAsync(int pageNumber, int pageSize);
}
