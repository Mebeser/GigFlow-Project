using MediatR;

namespace GigFlow.Application.Features.Profiles.Queries.SearchFreelancers;

public class SearchFreelancersQuery : IRequest<List<FreelancerSearchResultDto>>
{
    public string? SearchTerm { get; set; }
    public List<Guid>? SkillIds { get; set; }
    public decimal? MinHourlyRate { get; set; }
    public decimal? MaxHourlyRate { get; set; }
}

public class FreelancerSearchResultDto
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Title { get; set; }
    public decimal? HourlyRate { get; set; }
    public double AverageRating { get; set; }
    public List<string> Skills { get; set; } = new();
}
