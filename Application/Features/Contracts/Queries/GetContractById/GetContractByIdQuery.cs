using GigFlow.Application.Features.Contracts.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractById;

public class GetContractByIdQuery : IRequest<GetContractDto>
{
    public Guid Id { get; set; }
}
