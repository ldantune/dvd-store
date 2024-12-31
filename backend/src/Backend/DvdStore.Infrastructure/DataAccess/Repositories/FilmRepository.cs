using System.Text;
using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.Film;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class FilmRepository : IFilmReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public FilmRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }
    public async Task<Film> GetByFilmId(int filmId)
    {
        Film film = null!;
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT film_id, title, description, release_year, language_id, rental_duration, ");
            queryBuilder.AppendLine("rental_rate, length, replacement_cost, rating, last_update, special_features, fulltext ");
            queryBuilder.AppendLine("FROM film");
            queryBuilder.AppendLine("WHERE film_id = @filmId");

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@filmId", filmId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        film = new Film
                        {
                            FilmId = Convert.ToInt32(reader["film_id"]),
                            Title = reader["title"].ToString(),
                            Description = reader["description"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["release_year"]),
                            LanguageId = Convert.ToInt32(reader["language_id"]),
                            RentalDuration = Convert.ToInt32(reader["rental_duration"]),
                            RentalRate = Convert.ToDouble(reader["rental_rate"]),
                            Length = Convert.ToInt32(reader["length"]),
                            ReplacementCost = Convert.ToDouble(reader["replacement_cost"]),
                            Rating = reader["rating"].ToString(),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"]),
                            SpecialFeatures = reader["special_features"].ToString(),
                            FullText = reader["fulltext"].ToString()
                        };
                    }
                }
            }
        }
        return film;
    }
}
