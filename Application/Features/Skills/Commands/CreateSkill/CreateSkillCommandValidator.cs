using FluentValidation;

namespace GigFlow.Application.Features.Skills.Commands.CreateSkill;

public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Yetenek adı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Yetenek adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Lütfen yeteneğin bağlı olduğu kategoriyi seçiniz.");
    }
}
