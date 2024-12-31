using AutoMapper;
using DvdStore.Application.UseCases.Films.GetByFilmId;
using DvdStore.Communication.Responses.Inventory;
using DvdStore.Domain.Repositories.Film;
using DvdStore.Domain.Repositories.Inventory;
using DvdStore.Exceptions.ExceptionBase;

namespace DvdStore.Application.UseCases.Inventory.GetByInventoryId;

public class GetByInventoryIdUseCase : IGetByInventoryIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IInventoryReadOnlyRepository _inventoryReadOnlyRepository;
    private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;

    public GetByInventoryIdUseCase(IMapper mapper, IInventoryReadOnlyRepository inventoryReadOnlyRepository, IFilmReadOnlyRepository filmReadOnlyRepository)
    {
        _mapper = mapper;
        _inventoryReadOnlyRepository = inventoryReadOnlyRepository;
        _filmReadOnlyRepository = filmReadOnlyRepository;
    }

    public async Task<ResponseInventoryJson> Execute(int inventoryId)
    {
        
        var inventory = await _inventoryReadOnlyRepository.GetInventoryByIdAsync(inventoryId);

        if (inventory is null)
            throw new NotFoundException("Inventory not found");

        var film = await _filmReadOnlyRepository.GetByFilmId(inventory.FilmId);

        if (film is not null)
            inventory.Film = film;

        var response = _mapper.Map<ResponseInventoryJson>(inventory);

        return response;
    }
}
