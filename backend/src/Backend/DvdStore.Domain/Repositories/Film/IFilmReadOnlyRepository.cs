namespace DvdStore.Domain.Repositories.Film;

public interface IFilmReadOnlyRepository
{
    Task<Entities.Film> GetByFilmId(int filmId);
}
