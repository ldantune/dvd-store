using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.Address;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class AddressRepository : IAddressReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public AddressRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<Address> GetAddressByIdAsync(int addressId)
    {
        Address address = null!;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT a.address_id, a.address, a.address2, a.district, a.city_id, ");
            queryBuilder.AppendLine("a.postal_code, a.phone, a.last_update ");
            queryBuilder.AppendLine("FROM address a");
            queryBuilder.AppendLine("WHERE a.address_id = @addressId");

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@addressId", addressId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        address = new Address
                        {
                            AddressId = Convert.ToInt32(reader["address_id"]),
                            Address1 = reader["address"].ToString(),
                            Address2 = reader["address2"].ToString(),
                            District = reader["district"].ToString(),
                            CityId = Convert.ToInt32(reader["city_id"]),
                            PostalCode = reader["postal_code"].ToString(),
                            Phone = reader["phone"].ToString(),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"]),
                        };
                    }
                }
            }
        }
        return address;
    }
}
