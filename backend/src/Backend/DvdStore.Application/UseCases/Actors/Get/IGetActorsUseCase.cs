using DvdStore.Communication.Responses.Actors;

namespace DvdStore.Application.UseCases.Actors.Get;

public interface IGetActorsUseCase
{
    Task<ResponseActorsJson> Execute(int pageNumber, int pageSize);
}
