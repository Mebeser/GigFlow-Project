using AutoMapper;
using GigFlow.Application.Features.Proposals.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Proposals.Profiles;

public class ProposalProfile : Profile
{
    public ProposalProfile()
    {
        CreateMap<Proposal, GetProposalListDto>()
            .ForMember(dest => dest.JobPostingTitle, opt => opt.MapFrom(src => src.JobPosting != null ? src.JobPosting.Title : string.Empty))
            .ReverseMap();

        CreateMap<Proposal, GetProposalByIdDto>()
            .ForMember(dest => dest.JobPostingTitle, opt => opt.MapFrom(src => src.JobPosting != null ? src.JobPosting.Title : string.Empty))
            .ReverseMap();
    }
}
