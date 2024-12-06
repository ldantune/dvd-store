using DvdStore.Domain.Repositories;
using DvdStore.Domain.Repositories.Category;
using DvdStore.Infrastructure.DataAccess;
using DvdStore.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DvdStore.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryWriteOnlyRepository, CategoryRepository>();
        services.AddScoped<ICategoryUpdateOnlyRepository, CategoryRepository>();
    }
}
