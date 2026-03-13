using GigFlow.Application.Features.Portfolios.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Portfolios.Queries.GetPortfoliosByFreelancer;

public class GetPortfoliosByFreelancerQuery : IRequest<List<GetPortfolioDto>>
{
    public Guid FreelancerId { get; set; }
}
