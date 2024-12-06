using AutoMapper;
using DvdStore.Communication.Responses;
using DvdStore.Domain.Repositories.Category;
using DvdStore.Exceptions.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Application.UseCases.Categories;
public class GetCategoriesUseCase : IGetCategoriesUseCase
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesUseCase(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<ResponseCategoriesJson> Execute()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();

        return new ResponseCategoriesJson
        {
            Categories = _mapper.Map<IList<ResponseCategoryJson>>(categories)
        };
    }
}
