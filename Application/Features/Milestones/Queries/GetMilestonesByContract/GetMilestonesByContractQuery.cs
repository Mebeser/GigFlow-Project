using GigFlow.Application.Features.Milestones.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Milestones.Queries.GetMilestonesByContract;

public class GetMilestonesByContractQuery : IRequest<List<GetMilestoneDto>>
{
    public Guid ContractId { get; set; }
}
