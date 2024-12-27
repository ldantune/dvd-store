using DvdStore.Communication.Responses;

namespace DvdStore.Application.UseCases.Categories.Get;
public interface IGetCategoriesUseCase
{
    Task<ResponseCategoriesJson> Execute(int pageNumber, int pageSize, bool IsPaged);
}
