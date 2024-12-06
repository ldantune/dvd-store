using DvdStore.Communication.Requests;

namespace DvdStore.Application.UseCases.Categories.Update;
public interface IUpdateCategoryUseCase
{
    Task Execute(int categoryId, RequestCategoryJson request);
}
