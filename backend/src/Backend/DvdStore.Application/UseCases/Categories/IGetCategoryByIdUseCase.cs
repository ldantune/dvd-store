using DvdStore.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Application.UseCases.Categories;
public interface IGetCategoryByIdUseCase
{
    Task<ResponseCategoryJson> Execute(int categoryId);
}
