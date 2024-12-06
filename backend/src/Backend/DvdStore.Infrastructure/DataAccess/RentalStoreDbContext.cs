using Microsoft.EntityFrameworkCore;
using DvdStore.Domain.Entities;


namespace DvdStore.Infrastructure.DataAccess;
public class RentalStoreDbContext : DbContext
{
    public RentalStoreDbContext(DbContextOptions<RentalStoreDbContext> options) : base(options)
    { }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            // Mapeia a tabela
            entity.ToTable("category");

            // Mapeia a chave primária
            entity.HasKey(c => c.CategoryId)
                  .HasName("PK_category");

            // Mapeia a coluna 'category_id' para a propriedade 'CategoryId'
            entity.Property(c => c.CategoryId)
                  .HasColumnName("category_id")
                  .HasColumnType("integer");

            // Mapeia a coluna 'name' para a propriedade 'Name'
            entity.Property(c => c.Name)
                  .HasColumnName("name")
                  .HasMaxLength(25)
                  .HasColumnType("character varying(25)");

            // Mapeia a coluna 'last_name' para a propriedade 'LastName'
            entity.Property(c => c.LastUpdate)
                  .HasColumnName("last_update")
                  .HasColumnType("timestamp without time zone");
        });

    }


}
