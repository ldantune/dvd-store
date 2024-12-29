using System.Text;
using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.Customer;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class CustomerRepository : ICustomerReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public CustomerRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
         _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<(IList<Customer> Customers, int TotalItems)> GetCustomersAsync(int pageNumber, int pageSize)
    {
        var customers = new List<Customer>();
        var totalItems = 0;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM customer";
                totalItems = Convert.ToInt32(await command.ExecuteScalarAsync());
            }

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT customer_id, store_id, first_name, last_name, email, address_id, activebool, ");
            queryBuilder.AppendLine("create_date, last_update, active ");
            queryBuilder.AppendLine("FROM customer");
            queryBuilder.AppendLine("ORDER BY first_name");
            queryBuilder.AppendLine("LIMIT @PageSize OFFSET @Offset");

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                var offset = (pageNumber - 1) * pageSize;
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@Offset", offset);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId =  Convert.ToInt32(reader["customer_id"]),
                            StoreId =  Convert.ToInt32(reader["store_id"]),
                            FirstName =  reader["first_name"].ToString(),
                            LastName =  reader["last_name"].ToString(),
                            Email =  reader["email"].ToString(),
                            AddressId = Convert.ToInt32(reader["address_id"]),
                            Activebool = Convert.ToBoolean(reader["activebool"]),
                            CreateDate = DateHelper.ToFormattedDate(reader["last_update"]),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"]),
                            Active =  Convert.ToInt32(reader["active"])
                        });
                    }
                }
            }
        }

        return (customers, totalItems);
    }
}
