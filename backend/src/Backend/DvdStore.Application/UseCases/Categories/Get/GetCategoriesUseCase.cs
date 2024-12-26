using AutoMapper;
using DvdStore.Communication.Responses;
using DvdStore.Domain.Repositories.Category;

namespace DvdStore.Application.UseCases.Categories.Get;
public class GetCategoriesUseCase : IGetCategoriesUseCase
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesUseCase(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<ResponseCategoriesJson> Execute(int pageNumber, int pageSize)
    {
        var (categories, totalItems) = await _categoryRepository.GetCategoriesAsync(pageNumber, pageSize);

        return new ResponseCategoriesJson
        {
            Categories = _mapper.Map<IList<ResponseCategoryJson>>(categories),
            TotalItems = totalItems,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}
