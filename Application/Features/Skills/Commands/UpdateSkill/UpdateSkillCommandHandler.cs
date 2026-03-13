using GigFlow.Application.Repositories;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Skills.Commands.UpdateSkill;

public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, bool>
{
    private readonly ISkillRepository _skillRepository;

    public UpdateSkillCommandHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<bool> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        if (skill == null)
            throw new NotFoundException("Skill", request.Id);

        skill.Name = request.Name;
        skill.CategoryId = request.CategoryId;
        skill.UpdatedDate = DateTime.UtcNow;

        await _skillRepository.UpdateAsync(skill);
        return true;
    }
}
