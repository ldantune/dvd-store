using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Application.UseCases.Categories.Register;
public interface IRegisterCategoryUseCase
{
    public Task<ResponseCategoryJson> Execute(RequestCategoryJson request);
}
