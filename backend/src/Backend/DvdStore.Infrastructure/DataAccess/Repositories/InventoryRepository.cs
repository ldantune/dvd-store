using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.Inventory;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class InventoryRepository : IInventoryReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public InventoryRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
    {
        Inventory inventory = null!;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT inventory_id, film_id, store_id, last_update ");
            queryBuilder.AppendLine("FROM inventory");
            queryBuilder.AppendLine("WHERE inventory_id = @inventoryId");

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@inventoryId", inventoryId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        inventory = new Inventory
                        {
                            InventoryId = Convert.ToInt32(reader["inventory_id"]),
                            FilmId = Convert.ToInt32(reader["film_id"]),
                            StoreId = Convert.ToInt32(reader["store_id"]),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"]),
                        };
                    }
                }
            }
        }
        return inventory;
    }
}
