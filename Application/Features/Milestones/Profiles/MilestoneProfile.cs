using AutoMapper;
using GigFlow.Application.Features.Milestones.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Milestones.Profiles;

public class MilestoneProfile : Profile
{
    public MilestoneProfile()
    {
        CreateMap<Milestone, GetMilestoneDto>().ReverseMap();
    }
}
