using GigFlow.Application.Repositories;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Portfolios.Commands.UpdatePortfolio;

public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand, bool>
{
    private readonly IPortfolioRepository _portfolioRepository;

    public UpdatePortfolioCommandHandler(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    public async Task<bool> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
    {
        var portfolio = await _portfolioRepository.GetByIdAsync(request.Id);

        if (portfolio == null)
            throw new NotFoundException("Portfolio", request.Id);

        portfolio.Title = request.Title;
        portfolio.Description = request.Description;
        portfolio.ProjectUrl = request.ProjectUrl;
        portfolio.ImageUrl = request.ImageUrl;
        portfolio.UpdatedDate = DateTime.UtcNow;

        await _portfolioRepository.UpdateAsync(portfolio);
        return true;
    }
}
