using AutoMapper;
using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses;
using DvdStore.Communication.Responses.Actors;
using DvdStore.Communication.Responses.Address;
using DvdStore.Communication.Responses.City;
using DvdStore.Communication.Responses.Country;
using DvdStore.Communication.Responses.Customer;
using DvdStore.Communication.Responses.Inventory;
using DvdStore.Communication.Responses.Rental;
using DvdStore.Communication.Responses.Store;

namespace DvdStore.Application.Services.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
        DomainToResponse();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestCategoryJson, Domain.Entities.Category>();
    }

    private void DomainToResponse()
    {
        CreateMap<Domain.Entities.Category, ResponseCategoryJson>();
        CreateMap<Domain.Entities.MovieByCategory, ResponseMovieByCategoryJson>();
        CreateMap<Domain.Entities.Actor, ResponseActorJson>();
        CreateMap<Domain.Entities.Country, ResponseCountryJson>();
        CreateMap<Domain.Entities.City, ResponseCityJson>();
        CreateMap<Domain.Entities.Address, ResponseAddressJson>();
        CreateMap<Domain.Entities.Store, ResponseStoreJson>();
        CreateMap<Domain.Entities.Customer, ResponseCustomerJson>();
        CreateMap<Domain.Entities.Inventory, ResponseInventoryJson>();
        CreateMap<Domain.Entities.Rental, ResponseRentalJson>();
    }
}
