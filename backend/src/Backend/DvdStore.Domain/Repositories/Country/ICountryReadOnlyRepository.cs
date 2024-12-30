namespace DvdStore.Domain.Repositories.Country;

public interface ICountryReadOnlyRepository
{
    Task<Entities.Country> GetCountryByIdAsync(int countryId);
}
