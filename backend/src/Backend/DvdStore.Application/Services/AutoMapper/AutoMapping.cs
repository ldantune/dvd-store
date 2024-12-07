using AutoMapper;
using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses;

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
    }
}
