namespace DvdStore.Domain.Repositories.Customer;

public interface ICustomerReadOnlyRepository
{
    Task<(IList<Entities.Customer> Customers, int TotalItems)> GetCustomersAsync(int pageNumber, int pageSize);
    Task<Entities.Customer> GetCustomerByIdAsync(int customerId);
}
