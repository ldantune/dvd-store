using AutoMapper;
using DvdStore.Domain.Repositories;
using DvdStore.Domain.Repositories.Category;
using DvdStore.Exceptions.ExceptionBase;

namespace DvdStore.Application.UseCases.Categories.Delete;
public class DeleteCategoryUseCase : IDeleteCategoryUseCase
{
    private readonly ICategoryWriteOnlyRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCategoryUseCase(ICategoryWriteOnlyRepository repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Execute(int categoryId)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException("Categoria não encontrada");

        await _repository.Delete(categoryId);

        await _unitOfWork.Commit();


    }
}
