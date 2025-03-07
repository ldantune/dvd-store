﻿using DvdStore.Application.Services.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DvdStore.Application.UseCases.Categories.Get;
using DvdStore.Application.UseCases.Categories.GetById;
using DvdStore.Application.UseCases.Categories.Register;
using DvdStore.Application.UseCases.Categories.Update;
using DvdStore.Application.UseCases.Categories.Delete;
using DvdStore.Application.UseCases.Films.FilmCategory;
using DvdStore.Application.UseCases.Actors.Get;
using DvdStore.Application.UseCases.Customers.Get;
using DvdStore.Application.UseCases.Customers.GetByCustomerId;
using DvdStore.Application.UseCases.Rental.Get;
using DvdStore.Application.UseCases.Inventory.GetByInventoryId;
using DvdStore.Application.UseCases.Films.GetByFilmId;


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
        services.AddScoped<IRegisterCategoryUseCase, RegisterCategoryUseCase>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddScoped<IFilmCategoryUseCase, FilmCategoryUseCase>();
        services.AddScoped<IGetByFilmIdUseCase, GetByFilmIdUseCase>();

        services.AddScoped<IGetActorsUseCase, GetActorsUseCase>();
        services.AddScoped<IGetCustomersUseCase, GetCustomersUseCase>();
        services.AddScoped<IGetByCustomerIdUseCase, GetByCustomerIdUseCase>();
        services.AddScoped<IGetRentalsByCustomerIdUseCase, GetRentalsByCustomerIdUseCase>();
        services.AddScoped<IGetByInventoryIdUseCase, GetByInventoryIdUseCase>();
    }
}
