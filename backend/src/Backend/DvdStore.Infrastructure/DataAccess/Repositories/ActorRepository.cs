using DvdStore.Domain.Entities;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories.Actor;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Text;

namespace DvdStore.Infrastructure.DataAccess.Repositories;

public class ActorRepository : IActorReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly DvdStoreDbContext _dbContext;

    public ActorRepository(DvdStoreDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<(IList<Actor> Actors, int TotalItems)> GetActorsAsync(int pageNumber, int pageSize)
    {
        var actors = new List<Actor>();
        int totalItems = 0;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();


            using (var countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM actor", connection))
            {
                totalItems = Convert.ToInt32(await countCommand.ExecuteScalarAsync());
            }


            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT actor_id, first_name, last_name, last_update");
            queryBuilder.AppendLine("FROM actor");
            queryBuilder.AppendLine("ORDER BY actor_id");
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
                        actors.Add(new Actor
                        {
                            ActorId = Convert.ToInt32(reader["actor_id"]),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"])
                        });
                    }
                }
            }
        }

        return (actors, totalItems);
    }

    public async Task<Actor> GetActorByIdAsync(int id)
    {
        Actor actor = null!;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT actor_id, first_name, last_name, last_update FROM actor WHERE actor_id = @ActorId");

            using (var command = new NpgsqlCommand(queryBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@ActorId", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        actor = new Actor
                        {
                            ActorId = Convert.ToInt32(reader["actor_id"]),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            LastUpdate = DateHelper.ToFormattedDateTime(reader["last_update"])
                        };
                    }
                }
            }
        }

        return actor;
    }

}
