using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;

namespace GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio;

public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, Guid>
{
    private readonly IPortfolioRepository _portfolioRepository;

    public CreatePortfolioCommandHandler(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    public async Task<Guid> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
    {
        var portfolio = new Portfolio
        {
            Id = Guid.NewGuid(),
            FreelancerId = request.FreelancerId,
            Title = request.Title,
            Description = request.Description,
            ProjectUrl = request.ProjectUrl,
            ImageUrl = request.ImageUrl,
            CreatedDate = DateTime.UtcNow
        };

        await _portfolioRepository.AddAsync(portfolio);
        return portfolio.Id;
    }
}
