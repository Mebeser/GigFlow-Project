using MediatR;

namespace GigFlow.Application.Features.Portfolios.Commands.UpdatePortfolio;

public class UpdatePortfolioCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ProjectUrl { get; set; }
    public string? ImageUrl { get; set; }
}
