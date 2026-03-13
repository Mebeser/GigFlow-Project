using AutoMapper;
using GigFlow.Application.Features.Contracts.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByFreelancer;

public class GetContractsByFreelancerQueryHandler : IRequestHandler<GetContractsByFreelancerQuery, List<GetContractDto>>
{
    private readonly IContractRepository _contractRepository;
    private readonly IMapper _mapper;

    public GetContractsByFreelancerQueryHandler(IContractRepository contractRepository, IMapper mapper)
    {
        _contractRepository = contractRepository;
        _mapper = mapper;
    }

    public async Task<List<GetContractDto>> Handle(GetContractsByFreelancerQuery request, CancellationToken cancellationToken)
    {
        var contracts = await _contractRepository.GetAllAsync(c => c.FreelancerId == request.FreelancerId);
        return _mapper.Map<List<GetContractDto>>(contracts.OrderByDescending(c => c.CreatedDate).ToList());
    }
}
