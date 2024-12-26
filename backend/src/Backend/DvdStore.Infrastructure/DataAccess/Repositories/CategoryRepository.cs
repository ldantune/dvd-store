using DvdStore.Domain.Repositories.Category;
using Microsoft.Extensions.Configuration;
using DvdStore.Domain.Entities;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;
public class CategoryRepository : ICategoryRepository, ICategoryWriteOnlyRepository, ICategoryUpdateOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    // Injeção de dependência para pegar a connection string do arquivo de configuração
    public CategoryRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task Add(Category category) => await _dbContext.Categories.AddAsync(category);

    public async Task Delete(int id)
    {
        var category = await _dbContext.Categories.FindAsync(id);

        _dbContext.Categories.Remove(category!);
    }


    // Método para pegar todas as categorias
    public async Task<(IList<Category> Categories, int TotalItems)> GetCategoriesAsync(int pageNumber, int pageSize)
    {
        var categories = new List<Category>();
        var offset = (pageNumber - 1) * pageSize;
        int totalItems;


        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            // Consulta para obter o total de itens
            using (var countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM category", connection))
            {
                totalItems = Convert.ToInt32(await countCommand.ExecuteScalarAsync());
            }

            using (var command = new NpgsqlCommand("SELECT category_id, name, last_update FROM category ORDER BY category_id LIMIT @PageSize OFFSET @Offset", connection))
            {
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@Offset", offset);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            LastUpdate = reader.GetDateTime(2).ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("pt-BR"))
                        });
                    }
                }
            }
        }

        return (categories, totalItems);
    }

    // Método para pegar uma categoria pelo id
    public async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        Category category = null!;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand("SELECT category_id, name, last_update FROM category WHERE category_id = @CategoryId", connection))
            {
                command.Parameters.AddWithValue("@CategoryId", categoryId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        category = new Category
                        {
                            CategoryId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            LastUpdate = reader.GetDateTime(2).ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("pt-BR"))
                        };
                    }
                }
            }
        }

        return category!;
    }

    public void Update(Category category) => _dbContext.Categories.Update(category);
    
}
