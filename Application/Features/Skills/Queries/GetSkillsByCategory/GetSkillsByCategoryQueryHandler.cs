using AutoMapper;
using GigFlow.Application.Features.Skills.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillsByCategory;

public class GetSkillsByCategoryQueryHandler : IRequestHandler<GetSkillsByCategoryQuery, List<GetSkillsByCategoryDto>>
{
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;

    public GetSkillsByCategoryQueryHandler(ISkillRepository skillRepository, IMapper mapper)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<List<GetSkillsByCategoryDto>> Handle(GetSkillsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var skills = await _skillRepository.GetAllAsync(s => s.CategoryId == request.CategoryId);
        return _mapper.Map<List<GetSkillsByCategoryDto>>(skills);
    }
}
