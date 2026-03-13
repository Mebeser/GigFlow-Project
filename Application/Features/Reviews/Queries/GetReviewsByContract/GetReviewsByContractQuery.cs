using GigFlow.Application.Features.Reviews.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByContract;

public class GetReviewsByContractQuery : IRequest<List<GetReviewDto>>
{
    public Guid ContractId { get; set; }
}
