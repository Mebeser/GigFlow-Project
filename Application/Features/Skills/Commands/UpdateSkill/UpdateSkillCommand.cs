using MediatR;

namespace GigFlow.Application.Features.Skills.Commands.UpdateSkill;

public class UpdateSkillCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}
