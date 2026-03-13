using FluentValidation;

namespace GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio;

public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
{
    public CreatePortfolioCommandValidator()
    {
        RuleFor(x => x.FreelancerId).NotEmpty().WithMessage("FreelancerId is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title can be maximum 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(3000).WithMessage("Description can be maximum 3000 characters.");

        RuleFor(x => x.ProjectUrl)
            .MaximumLength(500).WithMessage("ProjectUrl can be maximum 500 characters.")
            .When(x => x.ProjectUrl != null);

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("ImageUrl can be maximum 500 characters.")
            .When(x => x.ImageUrl != null);
    }
}
