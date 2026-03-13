using GigFlow.Application.Features.Categories.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<GetCategoryByIdDto>
{
    public Guid Id { get; set; }
}
