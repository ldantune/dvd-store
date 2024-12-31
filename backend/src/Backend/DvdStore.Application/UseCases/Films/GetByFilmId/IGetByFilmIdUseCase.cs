using DvdStore.Communication.Responses.Film;

namespace DvdStore.Application.UseCases.Films.GetByFilmId;

public interface IGetByFilmIdUseCase
{
    Task<ResponseFilmJson> Execute(int filmId);
}   
