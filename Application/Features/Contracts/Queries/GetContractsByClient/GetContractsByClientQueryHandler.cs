using AutoMapper;
using GigFlow.Application.Features.Contracts.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByClient;

public class GetContractsByClientQueryHandler : IRequestHandler<GetContractsByClientQuery, List<GetContractDto>>
{
    private readonly IContractRepository _contractRepository;
    private readonly IMapper _mapper;

    public GetContractsByClientQueryHandler(IContractRepository contractRepository, IMapper mapper)
    {
        _contractRepository = contractRepository;
        _mapper = mapper;
    }

    public async Task<List<GetContractDto>> Handle(GetContractsByClientQuery request, CancellationToken cancellationToken)
    {
        var contracts = await _contractRepository.GetAllAsync(c => c.ClientId == request.ClientId);
        return _mapper.Map<List<GetContractDto>>(contracts.OrderByDescending(c => c.CreatedDate).ToList());
    }
}
