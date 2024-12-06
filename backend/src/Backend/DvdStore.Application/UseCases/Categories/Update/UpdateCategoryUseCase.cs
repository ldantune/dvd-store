using AutoMapper;
using DvdStore.Communication.Requests;
using DvdStore.Domain.Repositories.Category;
using DvdStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdStore.Domain.Extensions;
using DvdStore.Exceptions.ExceptionBase;
using DvdStore.Domain.Entities;

namespace DvdStore.Application.UseCases.Categories.Update;
public class UpdateCategoryUseCase : IUpdateCategoryUseCase
{
    private readonly ICategoryUpdateOnlyRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryUseCase(ICategoryUpdateOnlyRepository repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Execute(int categoryId, RequestCategoryJson request)
    {
        Validate(request);

        var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException("Categoria não encontrada");

        _mapper.Map(request, category);

        _repository.Update(category);

        await _unitOfWork.Commit();
    }

    private static void Validate(RequestCategoryJson request)
    {
        var result = new CategoryValidator().Validate(request);

        if (result.IsValid.IsFalse())
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
    }
}
