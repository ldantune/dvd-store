using System.Text;
using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.Country;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class CountryRepository : ICountryReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public CountryRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<Country> GetCountryByIdAsync(int countryId)
    {
        Country country = null!;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT c.country_id, c.country, c.last_update ");
            queryBuilder.AppendLine("FROM country c");
            queryBuilder.AppendLine("WHERE c.country_id = @countryId");

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@countryId", countryId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        country = new Country
                        {
                            CountryId = Convert.ToInt32(reader["country_id"]),
                            CountryName = reader["country"].ToString(),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"]),
                        };
                    }
                }
            }
        }
        return country;
    }
}
