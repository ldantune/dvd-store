using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DvdStore.Communication.Responses.Actors;
using DvdStore.Domain.Repositories.Actor;

namespace DvdStore.Application.UseCases.Actors.Get;

public class GetActorsUseCase : IGetActorsUseCase
{
    private readonly IMapper _mapper;
    private readonly IActorReadOnlyRepository _actorReadOnlyRepository;

    public GetActorsUseCase(IMapper mapper, IActorReadOnlyRepository actorReadOnlyRepository)
    {
        _mapper = mapper;
        _actorReadOnlyRepository = actorReadOnlyRepository;
    }

    public async Task<ResponseActorsJson> Execute(int pageNumber, int pageSize)
    {
        var (actors, totalItems) = await _actorReadOnlyRepository.GetActorsAsync(pageNumber, pageSize);

        var response = new ResponseActorsJson
        {
            Actors = _mapper.Map<IList<ResponseActorJson>>(actors),
            TotalItems = totalItems,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        return response;
    }
}
