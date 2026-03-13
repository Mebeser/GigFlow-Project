using GigFlow.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Application.Features.Profiles.Queries.SearchFreelancers;

public class SearchFreelancersQueryHandler : IRequestHandler<SearchFreelancersQuery, List<FreelancerSearchResultDto>>
{
    private readonly IFreelancerProfileRepository _freelancerRepository;

    public SearchFreelancersQueryHandler(IFreelancerProfileRepository freelancerRepository)
    {
        _freelancerRepository = freelancerRepository;
    }

    public async Task<List<FreelancerSearchResultDto>> Handle(SearchFreelancersQuery request, CancellationToken cancellationToken)
    {
        var profiles = await _freelancerRepository.GetAllAsync(p => 
            (!request.MinHourlyRate.HasValue || p.HourlyRate >= request.MinHourlyRate) &&
            (!request.MaxHourlyRate.HasValue || p.HourlyRate <= request.MaxHourlyRate) &&
            (string.IsNullOrEmpty(request.SearchTerm) || (p.Title != null && p.Title.Contains(request.SearchTerm)))
        );

        return profiles.Select(p => new FreelancerSearchResultDto
        {
            UserId = p.UserId,
            Title = p.Title,
            HourlyRate = p.HourlyRate,
            AverageRating = (double)p.AverageRating
        }).ToList();
    }
}
