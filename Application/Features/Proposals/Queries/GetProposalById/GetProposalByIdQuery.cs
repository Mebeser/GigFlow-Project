using GigFlow.Application.Features.Proposals.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Proposals.Queries.GetProposalById;

public class GetProposalByIdQuery : IRequest<GetProposalByIdDto>
{
    public Guid Id { get; set; }
}
