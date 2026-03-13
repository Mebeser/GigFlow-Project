using FluentValidation;

namespace GigFlow.Application.Features.Proposals.Commands.UpdateProposal;

public class UpdateProposalCommandValidator : AbstractValidator<UpdateProposalCommand>
{
    public UpdateProposalCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Teklif ID alanı boş bırakılamaz.");
        
        RuleFor(x => x.CoverLetter)
            .NotEmpty().WithMessage("Önyazı alanı boş bırakılamaz.")
            .MaximumLength(3000).WithMessage("Önyazı en fazla 3000 karakter olabilir.");

        RuleFor(x => x.ProposedAmount)
            .GreaterThan(0).WithMessage("Lütfen geçerli bir teklif tutarı giriniz.");

        RuleFor(x => x.EstimatedDuration)
            .GreaterThan(0).WithMessage("Lütfen tahmini teslim süresini belirtiniz.");
    }
}
