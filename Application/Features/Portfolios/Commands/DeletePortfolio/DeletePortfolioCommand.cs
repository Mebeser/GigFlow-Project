using MediatR;

namespace GigFlow.Application.Features.Portfolios.Commands.DeletePortfolio;

public class DeletePortfolioCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
