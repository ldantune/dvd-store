using AutoMapper;
using DvdStore.Communication.Responses;
using DvdStore.Domain.Repositories.Category;
using DvdStore.Exceptions.ExceptionBase;


namespace DvdStore.Application.UseCases.Categories.GetById;
public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdUseCase(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<ResponseCategoryJson> Execute(int categoryId)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException("Categoria não encontrada");

        var response = _mapper.Map<ResponseCategoryJson>(category);

        return response;
    }

}
