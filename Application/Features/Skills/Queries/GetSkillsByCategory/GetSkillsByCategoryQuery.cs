using GigFlow.Application.Features.Skills.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillsByCategory;

public class GetSkillsByCategoryQuery : IRequest<List<GetSkillsByCategoryDto>>
{
    public Guid CategoryId { get; set; }
}
