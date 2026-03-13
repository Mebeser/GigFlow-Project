using GigFlow.Application.Features.Contracts.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByClient;

public class GetContractsByClientQuery : IRequest<List<GetContractDto>>
{
    public Guid ClientId { get; set; }
}
