using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;

namespace GigFlow.Application.Features.Profiles.Commands.UpdateFreelancerSkills;

public class UpdateFreelancerSkillsCommandHandler : IRequestHandler<UpdateFreelancerSkillsCommand, Unit>
{
    private readonly IFreelancerProfileRepository _freelancerRepository;
    private readonly IGenericRepository<FreelancerSkill> _freelancerSkillRepository;

    public UpdateFreelancerSkillsCommandHandler(
        IFreelancerProfileRepository freelancerRepository,
        IGenericRepository<FreelancerSkill> freelancerSkillRepository)
    {
        _freelancerRepository = freelancerRepository;
        _freelancerSkillRepository = freelancerSkillRepository;
    }

    public async Task<Unit> Handle(UpdateFreelancerSkillsCommand request, CancellationToken cancellationToken)
    {
        var profiles = await _freelancerRepository.GetAllAsync(p => p.UserId == request.UserId);
        var profile = profiles.FirstOrDefault();
        if (profile == null) throw new Exception("Profil bulunamadı.");

        var currentSkills = await _freelancerSkillRepository.GetAllAsync(fs => fs.FreelancerProfileId == profile.Id);
        foreach (var skill in currentSkills)
        {
            await _freelancerSkillRepository.DeleteAsync(skill);
        }

        foreach (var skillId in request.SkillIds)
        {
            await _freelancerSkillRepository.AddAsync(new FreelancerSkill
            {
                Id = Guid.NewGuid(),
                FreelancerProfileId = profile.Id,
                SkillId = skillId,
                CreatedDate = DateTime.UtcNow
            });
        }

        return Unit.Value;
    }
}
