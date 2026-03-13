using AutoMapper;
using GigFlow.Application.Features.Categories.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Categories.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, GetCategoryListDto>().ReverseMap();
        CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
    }
}
