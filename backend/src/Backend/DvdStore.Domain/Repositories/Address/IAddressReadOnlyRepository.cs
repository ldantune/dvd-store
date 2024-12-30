namespace DvdStore.Domain.Repositories.Address;

public interface IAddressReadOnlyRepository
{
    Task<Entities.Address> GetAddressByIdAsync(int addressId);
}
