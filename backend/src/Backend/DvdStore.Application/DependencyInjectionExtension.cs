using DvdStore.Application.Services.AutoMapper;
using DvdStore.Application.UseCases.Categories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace DvdStore.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddAutoMapper(services);
        AddUserCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(autoMapperOptions =>
        {
            autoMapperOptions.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddUserCases(IServiceCollection services)
    {
        services.AddScoped<IGetCategoriesUseCase, GetCategoriesUseCase>();
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
    }
}
