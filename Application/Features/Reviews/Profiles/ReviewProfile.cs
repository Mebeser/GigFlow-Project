using AutoMapper;
using GigFlow.Application.Features.Reviews.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Reviews.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, GetReviewDto>().ReverseMap();
    }
}
