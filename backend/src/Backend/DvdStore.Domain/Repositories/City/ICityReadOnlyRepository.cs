namespace DvdStore.Domain.Repositories.City;

public interface ICityReadOnlyRepository
{
    Task<Entities.City> GetCityByIdAsync(int cityId);
}
