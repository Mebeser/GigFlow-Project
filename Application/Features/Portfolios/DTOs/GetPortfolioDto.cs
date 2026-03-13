namespace GigFlow.Application.Features.Portfolios.DTOs;

public class GetPortfolioDto
{
    public Guid Id { get; set; }
    public Guid FreelancerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ProjectUrl { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}
