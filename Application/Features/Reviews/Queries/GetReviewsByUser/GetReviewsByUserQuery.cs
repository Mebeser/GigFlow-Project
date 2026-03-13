using GigFlow.Application.Features.Reviews.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByUser;

public class GetReviewsByUserQuery : IRequest<List<GetReviewDto>>
{
    public Guid UserId { get; set; }
}
