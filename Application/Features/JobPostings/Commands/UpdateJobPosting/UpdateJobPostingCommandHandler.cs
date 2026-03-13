using GigFlow.Application.Exceptions;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Commands.UpdateJobPosting;

public class UpdateJobPostingCommandHandler : IRequestHandler<UpdateJobPostingCommand, bool>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IJobPostingSkillRepository _jobPostingSkillRepository;

    public UpdateJobPostingCommandHandler(
        IJobPostingRepository jobPostingRepository,
        IJobPostingSkillRepository jobPostingSkillRepository)
    {
        _jobPostingRepository = jobPostingRepository;
        _jobPostingSkillRepository = jobPostingSkillRepository;
    }

    public async Task<bool> Handle(UpdateJobPostingCommand request, CancellationToken cancellationToken)
    {
        var jobPosting = await _jobPostingRepository.GetByIdAsync(request.Id);

        if (jobPosting == null)
            throw new NotFoundException("Job Posting", request.Id);

        if (jobPosting.Status == JobStatus.Completed)
            throw new Exception("Cannot update a completed job posting.");

        jobPosting.Title = request.Title;
        jobPosting.Description = request.Description;
        jobPosting.CategoryId = request.CategoryId;
        jobPosting.BudgetMin = request.BudgetMin;
        jobPosting.BudgetMax = request.BudgetMax;
        jobPosting.BudgetType = request.BudgetType;
        jobPosting.Duration = request.Duration;
        jobPosting.ExperienceLevel = request.ExperienceLevel;
        jobPosting.Status = request.Status;
        jobPosting.Deadline = request.Deadline;
        jobPosting.UpdatedDate = DateTime.UtcNow;

        // Current skills
        var existingSkills = await _jobPostingSkillRepository.GetAllAsync(x => x.JobPostingId == request.Id);
        
        // Remove old skills
        foreach (var existingSkill in existingSkills)
        {
            await _jobPostingSkillRepository.DeleteAsync(existingSkill);
        }

        // Add new skills
        foreach (var skillId in request.SkillIds)
        {
            await _jobPostingSkillRepository.AddAsync(new JobPostingSkill
            {
                Id = Guid.NewGuid(),
                JobPostingId = jobPosting.Id,
                SkillId = skillId,
                CreatedDate = DateTime.UtcNow
            });
        }

        await _jobPostingRepository.UpdateAsync(jobPosting);

        return true;
    }
}
