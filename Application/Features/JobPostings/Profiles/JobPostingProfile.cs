using AutoMapper;
using GigFlow.Application.Features.JobPostings.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.JobPostings.Profiles;

public class JobPostingProfile : Profile
{
    public JobPostingProfile()
    {
        CreateMap<JobPosting, GetJobPostingListDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
            .ReverseMap();

        CreateMap<JobPosting, GetJobPostingByIdDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
            .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.JobPostingSkills.Select(js => js.Skill)))
            .ReverseMap();
    }
}
