namespace DvdStore.Application.UseCases.Categories.Delete;
public interface IDeleteCategoryUseCase
{
    Task Execute(int categoryId);
}
