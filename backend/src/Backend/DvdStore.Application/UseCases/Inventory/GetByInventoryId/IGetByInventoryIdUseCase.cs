using DvdStore.Communication.Responses.Inventory;

namespace DvdStore.Application.UseCases.Inventory.GetByInventoryId;

public interface IGetByInventoryIdUseCase
{
    Task<ResponseInventoryJson> Execute(int inventoryId);
}
