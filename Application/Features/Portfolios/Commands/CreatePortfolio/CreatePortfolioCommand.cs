using MediatR;

namespace GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio;

public class CreatePortfolioCommand : IRequest<Guid>
{
    public Guid FreelancerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ProjectUrl { get; set; }
    public string? ImageUrl { get; set; }
}
