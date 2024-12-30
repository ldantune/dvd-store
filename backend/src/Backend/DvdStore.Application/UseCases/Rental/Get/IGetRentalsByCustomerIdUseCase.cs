using DvdStore.Communication.Responses.Rental;

namespace DvdStore.Application.UseCases.Rental.Get;

public interface IGetRentalsByCustomerIdUseCase
{
    Task<ResponseRentalsJson> ExecuteAsync(int customerId, int pageNumber, int pageSize, bool isPaged = true);
}
