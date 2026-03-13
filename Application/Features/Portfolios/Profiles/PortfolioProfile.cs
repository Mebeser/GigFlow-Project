using AutoMapper;
using GigFlow.Application.Features.Portfolios.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Portfolios.Profiles;

public class PortfolioProfile : Profile
{
    public PortfolioProfile()
    {
        CreateMap<Portfolio, GetPortfolioDto>().ReverseMap();
    }
}
