using AutoMapper;
using GigFlow.Application.Features.Proposals.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Proposals.Queries.GetProposalsByJobPosting;

public class GetProposalsByJobPostingQueryHandler : IRequestHandler<GetProposalsByJobPostingQuery, List<GetProposalListDto>>
{
    private readonly IProposalRepository _proposalRepository;
    private readonly IMapper _mapper;

    public GetProposalsByJobPostingQueryHandler(IProposalRepository proposalRepository, IMapper mapper)
    {
        _proposalRepository = proposalRepository;
        _mapper = mapper;
    }

    public async Task<List<GetProposalListDto>> Handle(GetProposalsByJobPostingQuery request, CancellationToken cancellationToken)
    {
        var proposals = await _proposalRepository.GetAllAsync(p => p.JobPostingId == request.JobPostingId);
        return _mapper.Map<List<GetProposalListDto>>(proposals.OrderByDescending(p => p.CreatedDate).ToList());
    }
}
