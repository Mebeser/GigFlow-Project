using GigFlow.Application.Repositories;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category == null)
            throw new NotFoundException("Category", request.Id);

        await _categoryRepository.DeleteAsync(category);
        return true;
    }
}
