using FluentValidation;

namespace GigFlow.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Kategori ID alanı boş bırakılamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.")
            .When(x => x.Description != null);
    }
}
