using DvdStore.Domain.Repositories.Category;
using Microsoft.Extensions.Configuration;
using DvdStore.Domain.Entities;
using Npgsql;
using System.Text;
using DvdStore.Domain.Extensions;

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
    public async Task<(IList<Category> Categories, int TotalItems)> GetCategoriesAsync(int pageNumber, int pageSize, bool isPaged = true)
    {
        var categories = new List<Category>();
        int totalItems = 0;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            // Se a paginação estiver ativada, conta o total de itens
            if (isPaged)
            {
                using (var countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM category", connection))
                {
                    totalItems = Convert.ToInt32(await countCommand.ExecuteScalarAsync());
                }
            }

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT category_id, name, last_update");
            queryBuilder.AppendLine("FROM category");
            queryBuilder.AppendLine("ORDER BY category_id");

            if (isPaged)
            {
                queryBuilder.AppendLine("LIMIT @PageSize OFFSET @Offset");
            }

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                if (isPaged)
                {
                    var offset = (pageNumber - 1) * pageSize;
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", offset);
                }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(reader["category_id"]),
                            Name = reader["name"].ToString(),
                            LastUpdate =  DateHelper.ToFormattedDateTime(reader["last_update"])
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
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"])
                        };
                    }
                }
            }
        }

        return category!;
    }

    public void Update(Category category) => _dbContext.Categories.Update(category);

}
