using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.City;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Text;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class CityRepository : ICityReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public CityRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<City> GetCityByIdAsync(int cityId)
    {
        City city = null!;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT c.city_id, c.city, c.country_id, c.last_update ");
            queryBuilder.AppendLine("FROM city c");
            queryBuilder.AppendLine("WHERE c.city_id = @cityId");

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@cityId", cityId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        city = new City
                        {
                            CityId = Convert.ToInt32(reader["city_id"]),
                            CityName = reader["city"].ToString(),
                            CountryId = Convert.ToInt32(reader["country_id"]),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"]),
                        };
                    }
                }
            }
        }
        return city;
    }
}
