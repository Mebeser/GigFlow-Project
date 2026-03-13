using GigFlow.Application.Features.Contracts.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByFreelancer;

public class GetContractsByFreelancerQuery : IRequest<List<GetContractDto>>
{
    public Guid FreelancerId { get; set; }
}
