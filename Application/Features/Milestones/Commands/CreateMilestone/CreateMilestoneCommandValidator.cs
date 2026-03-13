using FluentValidation;

namespace GigFlow.Application.Features.Milestones.Commands.CreateMilestone;

public class CreateMilestoneCommandValidator : AbstractValidator<CreateMilestoneCommand>
{
    public CreateMilestoneCommandValidator()
    {
        RuleFor(x => x.ContractId).NotEmpty().WithMessage("Hakedişin bağlı olduğu sözleşme belirtilmelidir.");
        
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Hakediş başlığı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("Hakediş başlığı en fazla 200 karakter olabilir.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Hakediş miktarı 0'dan büyük olmalıdır.");

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("Teslim tarihi gelecekte bir zaman olmalıdır.");
    }
}
