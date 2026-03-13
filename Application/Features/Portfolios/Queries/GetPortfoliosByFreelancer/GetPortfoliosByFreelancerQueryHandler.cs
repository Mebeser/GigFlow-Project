using AutoMapper;
using GigFlow.Application.Features.Portfolios.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Portfolios.Queries.GetPortfoliosByFreelancer;

public class GetPortfoliosByFreelancerQueryHandler : IRequestHandler<GetPortfoliosByFreelancerQuery, List<GetPortfolioDto>>
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly IMapper _mapper;

    public GetPortfoliosByFreelancerQueryHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
    {
        _portfolioRepository = portfolioRepository;
        _mapper = mapper;
    }

    public async Task<List<GetPortfolioDto>> Handle(GetPortfoliosByFreelancerQuery request, CancellationToken cancellationToken)
    {
        var portfolios = await _portfolioRepository.GetAllAsync(p => p.FreelancerId == request.FreelancerId);
        return _mapper.Map<List<GetPortfolioDto>>(portfolios.OrderByDescending(p => p.CreatedDate).ToList());
    }
}
