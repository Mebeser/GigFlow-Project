using GigFlow.Application.Repositories;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Portfolios.Commands.DeletePortfolio;

public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, bool>
{
    private readonly IPortfolioRepository _portfolioRepository;

    public DeletePortfolioCommandHandler(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    public async Task<bool> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
    {
        var portfolio = await _portfolioRepository.GetByIdAsync(request.Id);

        if (portfolio == null)
            throw new NotFoundException("Portfolio", request.Id);

        await _portfolioRepository.DeleteAsync(portfolio);
        return true;
    }
}
