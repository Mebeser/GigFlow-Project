using MediatR;

namespace GigFlow.Application.Features.JobPostings.Commands.DeleteJobPosting;

public class DeleteJobPostingCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
