using GigFlow.Application.Features.Skills.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillById;

public class GetSkillByIdQuery : IRequest<GetSkillByIdDto>
{
    public Guid Id { get; set; }
}
