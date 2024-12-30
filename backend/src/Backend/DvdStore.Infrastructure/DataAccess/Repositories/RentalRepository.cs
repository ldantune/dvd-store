using System.Text;
using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.Rental;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class RentalRepository : IRentalReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public RentalRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<(IList<Rental> Rentals, int TotalItems)> GetRentalsByCustomerIdAsync(int customerId, int pageNumber, int pageSize, bool isPaged = true)
    {
        var rentals = new List<Rental>();
        var totalItems = 0;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            if (isPaged)
            {
                using (var countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM rental WHERE customer_id = @Idcustomer", connection))
                {
                    countCommand.Parameters.AddWithValue("@Idcustomer", customerId);
                    totalItems = Convert.ToInt32(await countCommand.ExecuteScalarAsync());
                }
            }

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT rental_id, rental_date, inventory_id, customer_id, return_date, staff_id, last_update ");
            queryBuilder.AppendLine("FROM rental");
            queryBuilder.AppendLine("WHERE customer_id = @customerId");
            queryBuilder.AppendLine("ORDER BY rental_date desc");

            if (isPaged)
            {
                queryBuilder.AppendLine("LIMIT @PageSize OFFSET @Offset");
            }

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
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
                        rentals.Add(new Rental
                        {
                            RentalId = Convert.ToInt32(reader["rental_id"]),
                            RentalDate = DateHelper.ToFormattedDateTime(reader["rental_date"]),
                            InventoryId = Convert.ToInt32(reader["inventory_id"]),
                            CustomerId = Convert.ToInt32(reader["customer_id"]),
                            ReturnDate = DateHelper.ToFormattedDateTime(reader["return_date"]),
                            StaffId = Convert.ToInt32(reader["staff_id"]),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"])
                        });
                    }
                }
            }
        }

        return (rentals, totalItems);
    }
}
