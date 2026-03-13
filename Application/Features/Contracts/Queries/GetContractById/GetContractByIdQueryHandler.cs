using AutoMapper;
using GigFlow.Application.Features.Contracts.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractById;

public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery, GetContractDto>
{
    private readonly IContractRepository _contractRepository;
    private readonly IMapper _mapper;

    public GetContractByIdQueryHandler(IContractRepository contractRepository, IMapper mapper)
    {
        _contractRepository = contractRepository;
        _mapper = mapper;
    }

    public async Task<GetContractDto> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetContractDto>(contract);
    }
}
