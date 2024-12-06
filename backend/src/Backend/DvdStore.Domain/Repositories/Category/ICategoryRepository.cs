using DvdStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Domain.Repositories.Category;
public interface ICategoryRepository
{
    Task<IList<Entities.Category>> GetCategoriesAsync();
    Task<Entities.Category> GetCategoryByIdAsync(int categoryId);
}
