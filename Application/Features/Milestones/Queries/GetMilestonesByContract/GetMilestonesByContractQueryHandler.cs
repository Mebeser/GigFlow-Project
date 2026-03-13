using AutoMapper;
using GigFlow.Application.Features.Milestones.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Milestones.Queries.GetMilestonesByContract;

public class GetMilestonesByContractQueryHandler : IRequestHandler<GetMilestonesByContractQuery, List<GetMilestoneDto>>
{
    private readonly IMilestoneRepository _milestoneRepository;
    private readonly IMapper _mapper;

    public GetMilestonesByContractQueryHandler(IMilestoneRepository milestoneRepository, IMapper mapper)
    {
        _milestoneRepository = milestoneRepository;
        _mapper = mapper;
    }

    public async Task<List<GetMilestoneDto>> Handle(GetMilestonesByContractQuery request, CancellationToken cancellationToken)
    {
        var milestones = await _milestoneRepository.GetAllAsync(m => m.ContractId == request.ContractId);
        return _mapper.Map<List<GetMilestoneDto>>(milestones.OrderBy(m => m.CreatedDate).ToList());
    }
}
