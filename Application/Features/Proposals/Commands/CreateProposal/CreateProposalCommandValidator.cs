using FluentValidation;

namespace GigFlow.Application.Features.Proposals.Commands.CreateProposal;

public class CreateProposalCommandValidator : AbstractValidator<CreateProposalCommand>
{
    public CreateProposalCommandValidator()
    {
        RuleFor(x => x.JobPostingId).NotEmpty().WithMessage("Lütfen teklif verilecek ilanı seçiniz.");
        
        RuleFor(x => x.CoverLetter)
            .NotEmpty().WithMessage("Önyazı alanı boş bırakılamaz.")
            .MaximumLength(3000).WithMessage("Önyazı en fazla 3000 karakter olabilir.");

        RuleFor(x => x.ProposedAmount)
            .GreaterThan(0).WithMessage("Lütfen geçerli bir teklif tutarı giriniz.");

        RuleFor(x => x.EstimatedDuration)
            .GreaterThan(0).WithMessage("Lütfen tahmini teslim süresini belirtiniz.");
    }
}
