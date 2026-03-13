using GigFlow.Application.Features.Categories.DTOs;
using MediatR;

namespace GigFlow.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryListQuery : IRequest<List<GetCategoryListDto>>
{
}
