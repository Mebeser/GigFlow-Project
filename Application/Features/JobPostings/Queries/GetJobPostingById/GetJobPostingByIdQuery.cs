using GigFlow.Application.Features.JobPostings.DTOs;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingById;

public class GetJobPostingByIdQuery : IRequest<GetJobPostingByIdDto>
{
    public Guid Id { get; set; }
}
