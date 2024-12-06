using AutoMapper;
using DvdStore.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }

    private void DomainToResponse()
    {
        CreateMap<Domain.Entities.Category, ResponseCategoryJson>();
    }
}
