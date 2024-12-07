using DvdStore.Communication.Responses;

namespace DvdStore.Application.UseCases.Films.FilmCategory;
public interface IFilmCategoryUseCase
{
    Task<ResponseMoviesByCategoryJson> Execute(int category_id);
}
