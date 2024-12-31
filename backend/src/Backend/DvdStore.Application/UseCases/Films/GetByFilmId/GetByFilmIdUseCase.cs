using AutoMapper;
using DvdStore.Communication.Responses.Film;
using DvdStore.Domain.Repositories.Film;
using DvdStore.Exceptions.ExceptionBase;

namespace DvdStore.Application.UseCases.Films.GetByFilmId;

public class GetByFilmIdUseCase : IGetByFilmIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;

    public GetByFilmIdUseCase(IMapper mapper, IFilmReadOnlyRepository filmReadOnlyRepository)
    {
        _mapper = mapper;
        _filmReadOnlyRepository = filmReadOnlyRepository;
    }
    public async Task<ResponseFilmJson> Execute(int filmId)
    {
        var film = await _filmReadOnlyRepository.GetByFilmId(filmId);

        if(film is null)
            throw new NotFoundException("Film not found");

        var response = _mapper.Map<ResponseFilmJson>(film);

        return response;
    }
}
