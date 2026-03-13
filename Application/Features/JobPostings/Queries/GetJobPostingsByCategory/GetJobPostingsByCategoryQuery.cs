using GigFlow.Application.Features.JobPostings.DTOs;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingsByCategory;

public class GetJobPostingsByCategoryQuery : IRequest<List<GetJobPostingListDto>>
{
    public Guid CategoryId { get; set; }
}
