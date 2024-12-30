namespace DvdStore.Domain.Repositories.Rental;

public interface IRentalReadOnlyRepository
{
    Task<(IList<Entities.Rental> Rentals, int TotalItems)> GetRentalsByCustomerIdAsync(int customerId, int pageNumber, int pageSize, bool isPaged);
}
