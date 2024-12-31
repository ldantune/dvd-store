namespace DvdStore.Domain.Repositories.Inventory;

public interface IInventoryReadOnlyRepository
{
     Task<Entities.Inventory> GetInventoryByIdAsync(int inventoryId);
}
