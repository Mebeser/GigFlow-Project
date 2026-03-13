using AutoMapper;
using GigFlow.Application.Features.Skills.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Skills.Profiles;

public class SkillProfile : Profile
{
    public SkillProfile()
    {
        CreateMap<Skill, GetSkillListDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
            .ReverseMap();

        CreateMap<Skill, GetSkillByIdDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
            .ReverseMap();

        CreateMap<Skill, GetSkillsByCategoryDto>().ReverseMap();
    }
}
