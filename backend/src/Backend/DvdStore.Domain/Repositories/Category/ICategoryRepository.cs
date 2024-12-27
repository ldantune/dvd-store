namespace DvdStore.Domain.Repositories.Category;
public interface ICategoryRepository
{
    Task<(IList<Entities.Category> Categories, int TotalItems)> GetCategoriesAsync(int pageNumber, int pageSize, bool isPaged);
    Task<Entities.Category> GetCategoryByIdAsync(int categoryId);
}
