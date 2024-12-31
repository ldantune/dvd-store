using DvdStore.Domain.Entities;
using DvdStore.Domain.Repositories.Film;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Infrastructure.DataAccess.Repositories;
public class FilmCategoryRepository : IFilmCategory
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public FilmCategoryRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<IList<MovieByCategory>> GetMoviesByCategoryAsync(int category_id)
    {
        var movieByCategory = new List<MovieByCategory>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(" select f.film_id, f.title, f.description, f.release_year, " +
                "f.replacement_cost, l.name as language_name, c.name as name_category" +
                " from film f" +
                " inner join language l on l.language_id = f.language_id" +
                " inner join film_category fc on fc.film_id = f.film_id" +
                " inner join category c on c.category_id = fc.category_id " +
                " WHERE fc.category_id = @CategoryId", connection))
            {
                command.Parameters.AddWithValue("@CategoryId", category_id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        movieByCategory.Add(new MovieByCategory
                        {
                            FilmId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            ReleaseYear = reader.GetInt32(3),
                            ReplacementCost = reader.GetDouble(4),
                            Language = reader.GetString(5),
                            NameCategory = reader.GetString(6),
                        });
                    }
                }
            }
        }

        return movieByCategory;
    }
}
