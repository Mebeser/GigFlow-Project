using GigFlow.Application.Features.JobPostings.DTOs;
using GigFlow.Application.Responses;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Queries.GetAllJobPostings;

public class GetAllJobPostingsQuery : IRequest<PaginatedResult<GetJobPostingListDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
    // Filtering options
    public string? SearchTerm { get; set; }
    public Guid? CategoryId { get; set; }
}
