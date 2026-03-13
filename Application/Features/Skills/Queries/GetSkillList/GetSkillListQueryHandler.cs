using AutoMapper;
using GigFlow.Application.Features.Skills.DTOs;
using GigFlow.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillList;

public class GetSkillListQueryHandler : IRequestHandler<GetSkillListQuery, List<GetSkillListDto>>
{
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;

    public GetSkillListQueryHandler(ISkillRepository skillRepository, IMapper mapper)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<List<GetSkillListDto>> Handle(GetSkillListQuery request, CancellationToken cancellationToken)
    {
        // Category verisiyle gelmesini istiyorsak Queryable ile çekip Include yapabiliriz, 
        // ya da GetAllAsync metodu Include destekleyecek sekilde tasarlanmali.
        // IGenericRepository IQueryable veya func argument alıyorsa şu an IQueryable değil
        // Sadece temel IEnumerable çekebiliriz, auto-include Persistence tarafında mı?
        // Navigation Property: Category. Name bilgisini alması mühim.
        // Persistence'de Auto-Include configure edilmememişse categoryName boş gelebilir. (Şimdilik mapping yapacağız, test ederiz).
        var skills = await _skillRepository.GetAllAsync();
        return _mapper.Map<List<GetSkillListDto>>(skills);
    }
}
