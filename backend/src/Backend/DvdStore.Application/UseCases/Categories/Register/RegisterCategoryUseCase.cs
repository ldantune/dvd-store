using AutoMapper;
using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses;
using DvdStore.Domain.Extensions;
using DvdStore.Domain.Repositories;
using DvdStore.Domain.Repositories.Category;
using DvdStore.Exceptions.ExceptionBase;

namespace DvdStore.Application.UseCases.Categories.Register;
public class RegisterCategoryUseCase : IRegisterCategoryUseCase
{
    private readonly ICategoryWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterCategoryUseCase(ICategoryWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseCategoryJson> Execute(RequestCategoryJson request)
    {
        Validate(request);

        var category = _mapper.Map<Domain.Entities.Category>(request);

        category.LastUpdate = DateTime.Now;

        await _repository.Add(category);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseCategoryJson>(category);
    }

    private static void Validate(RequestCategoryJson request)
    {
        var result = new CategoryValidator().Validate(request);

        if(result.IsValid.IsFalse()) 
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
    }
}
