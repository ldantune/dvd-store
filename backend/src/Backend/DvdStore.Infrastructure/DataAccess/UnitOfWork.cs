using DvdStore.Domain.Repositories;

namespace DvdStore.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly RentalStoreDbContext _dbContext;

    public UnitOfWork(RentalStoreDbContext dbContext) => _dbContext = dbContext;
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
