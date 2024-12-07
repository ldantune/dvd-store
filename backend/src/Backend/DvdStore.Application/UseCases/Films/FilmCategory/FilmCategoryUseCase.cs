using AutoMapper;
using DvdStore.Communication.Responses;
using DvdStore.Domain.Repositories.Film;

namespace DvdStore.Application.UseCases.Films.FilmCategory;
public class FilmCategoryUseCase : IFilmCategoryUseCase
{
    private readonly IMapper _mapper;
    private readonly IFilmCategory _filmCategoryRepository;

    public FilmCategoryUseCase(IMapper mapper, IFilmCategory filmCategoryRepository)
    {
        _mapper = mapper;
        _filmCategoryRepository = filmCategoryRepository;
    }

    public async Task<ResponseMoviesByCategoryJson> Execute(int category_id)
    {
        var filmsCategories = await _filmCategoryRepository.GetMoviesByCategoryAsync(category_id);

        return new ResponseMoviesByCategoryJson
        {
            MoviesByCategory = _mapper.Map<IList<ResponseMovieByCategoryJson>>(filmsCategories)
        };
    }
}
