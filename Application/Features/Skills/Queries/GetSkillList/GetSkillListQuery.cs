using GigFlow.Application.Features.Skills.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillList;

public class GetSkillListQuery : IRequest<List<GetSkillListDto>>
{
}
