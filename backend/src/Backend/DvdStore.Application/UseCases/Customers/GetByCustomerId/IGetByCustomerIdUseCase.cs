using DvdStore.Communication.Responses.Customer;

namespace DvdStore.Application.UseCases.Customers.GetByCustomerId;

public interface IGetByCustomerIdUseCase
{
    Task<ResponseCustomerJson> ExecuteAsync(int customerId);
}
