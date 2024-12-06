using DvdStore.Domain.Repositories;

namespace DvdStore.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly DvdStoreDbContext _dbContext;

    public UnitOfWork(DvdStoreDbContext dbContext) => _dbContext = dbContext;
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
