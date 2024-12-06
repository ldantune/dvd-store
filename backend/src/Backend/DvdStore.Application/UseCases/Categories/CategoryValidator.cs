using DvdStore.Communication.Requests;
using FluentValidation;

namespace DvdStore.Application.UseCases.Categories;
public class CategoryValidator : AbstractValidator<RequestCategoryJson>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name).NotEmpty().WithMessage("Nome da categoria não pode ser vazio");
    }
}
