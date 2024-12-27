namespace DvdStore.Domain.Repositories.Actor;

public interface IActorReadOnlyRepository
{
    Task<(IList<Entities.Actor> Actors, int TotalItems)> GetActorsAsync(int pageNumber, int pageSize);
    Task<Entities.Actor> GetActorByIdAsync(int actorId);
}
