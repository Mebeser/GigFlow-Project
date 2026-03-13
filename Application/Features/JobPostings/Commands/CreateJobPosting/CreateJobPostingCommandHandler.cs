using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;

public class CreateJobPostingCommandHandler : IRequestHandler<CreateJobPostingCommand, Guid>
{
    private readonly IJobPostingRepository _jobPostingRepository;

    public CreateJobPostingCommandHandler(IJobPostingRepository jobPostingRepository)
    {
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<Guid> Handle(CreateJobPostingCommand request, CancellationToken cancellationToken)
    {
        var jobPosting = new JobPosting
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CategoryId = request.CategoryId,
            BudgetMin = request.BudgetMin,
            BudgetMax = request.BudgetMax,
            BudgetType = request.BudgetType,
            Duration = request.Duration,
            ExperienceLevel = request.ExperienceLevel,
            ClientId = request.ClientId,
            Deadline = request.Deadline,
            Status = JobStatus.Open,
            CreatedDate = DateTime.UtcNow
        };

        // Skill ataması
        foreach (var skillId in request.SkillIds)
        {
            jobPosting.JobPostingSkills.Add(new JobPostingSkill
            {
                Id = Guid.NewGuid(),
                JobPostingId = jobPosting.Id,
                SkillId = skillId,
                CreatedDate = DateTime.UtcNow
            });
        }

        await _jobPostingRepository.AddAsync(jobPosting);
        return jobPosting.Id;
    }
}
