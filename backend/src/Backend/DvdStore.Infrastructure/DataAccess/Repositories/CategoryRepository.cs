using DvdStore.Domain.Repositories.Category;
using Microsoft.Extensions.Configuration;
using DvdStore.Domain.Entities;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly string _connectionString;

    // Injeção de dependência para pegar a connection string do arquivo de configuração
    public CategoryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    // Método para pegar todas as categorias
    public async Task<IList<Category>> GetCategoriesAsync()
    {
        var categories = new List<Category>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand("SELECT category_id, name, last_update FROM category", connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            LastUpdate = reader.GetDateTime(2)
                        });
                    }
                }
            }
        }

        return categories;
    }

    // Método para pegar uma categoria pelo id
    public async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        Category category = null;

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
                            LastUpdate = reader.GetDateTime(2)
                        };
                    }
                }
            }
        }

        return category!;
    }
}
