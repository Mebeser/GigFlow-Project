namespace GigFlow.Application.Features.Categories.DTOs;

public class GetCategoryListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
