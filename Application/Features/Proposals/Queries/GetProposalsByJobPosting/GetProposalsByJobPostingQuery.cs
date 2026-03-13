using GigFlow.Application.Features.Proposals.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Proposals.Queries.GetProposalsByJobPosting;

public class GetProposalsByJobPostingQuery : IRequest<List<GetProposalListDto>>
{
    public Guid JobPostingId { get; set; }
}
