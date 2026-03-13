using AutoMapper;
using GigFlow.Application.Features.Skills.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillById;

public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, GetSkillByIdDto>
{
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;

    public GetSkillByIdQueryHandler(ISkillRepository skillRepository, IMapper mapper)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<GetSkillByIdDto> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetSkillByIdDto>(skill);
    }
}
