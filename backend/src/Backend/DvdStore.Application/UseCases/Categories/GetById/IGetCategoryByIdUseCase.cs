using DvdStore.Communication.Responses;


namespace DvdStore.Application.UseCases.Categories.GetById;
public interface IGetCategoryByIdUseCase
{
    Task<ResponseCategoryJson> Execute(int categoryId);
}
