using AutoMapper;
using GigFlow.Application.Features.Proposals.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Proposals.Queries.GetProposalById;

public class GetProposalByIdQueryHandler : IRequestHandler<GetProposalByIdQuery, GetProposalByIdDto>
{
    private readonly IProposalRepository _proposalRepository;
    private readonly IMapper _mapper;

    public GetProposalByIdQueryHandler(IProposalRepository proposalRepository, IMapper mapper)
    {
        _proposalRepository = proposalRepository;
        _mapper = mapper;
    }

    public async Task<GetProposalByIdDto> Handle(GetProposalByIdQuery request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetProposalByIdDto>(proposal);
    }
}
