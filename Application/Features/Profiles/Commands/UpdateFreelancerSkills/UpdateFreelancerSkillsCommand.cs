using MediatR;

namespace GigFlow.Application.Features.Profiles.Commands.UpdateFreelancerSkills;

public class UpdateFreelancerSkillsCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public List<Guid> SkillIds { get; set; } = new();
}
