namespace GigFlow.Application.Features.Reviews.DTOs;

public class GetReviewDto
{
    public Guid Id { get; set; }
    public Guid ContractId { get; set; }
    public Guid ReviewerId { get; set; }
    public Guid RevieweeId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedDate { get; set; }
}
