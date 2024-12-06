namespace DvdStore.Domain.Repositories.Category;
public interface ICategoryRepository
{
    Task<IList<Entities.Category>> GetCategoriesAsync();
    Task<Entities.Category> GetCategoryByIdAsync(int categoryId);
}
