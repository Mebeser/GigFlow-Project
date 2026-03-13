using AutoMapper;
using GigFlow.Application.Features.Contracts.DTOs;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Contracts.Profiles;

public class ContractProfile : Profile
{
    public ContractProfile()
    {
        CreateMap<Contract, GetContractDto>().ReverseMap();
    }
}
