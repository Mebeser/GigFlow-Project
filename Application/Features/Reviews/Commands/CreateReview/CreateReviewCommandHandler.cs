using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IContractRepository _contractRepository;

    public CreateReviewCommandHandler(
        IReviewRepository reviewRepository,
        IContractRepository contractRepository)
    {
        _reviewRepository = reviewRepository;
        _contractRepository = contractRepository;
    }

    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        // Kritik kural: Sadece Completed sözleşmeler için review yapılabilir
        var contract = await _contractRepository.GetByIdAsync(request.ContractId);
        if (contract == null)
            throw new Exception("Contract not found.");

        if (contract.Status != ContractStatus.Completed)
            throw new Exception("Reviews can only be created for completed contracts.");

        // Kritik kural: Aynı kişi aynı sözleşme için birden fazla review yapamaz
        var existingReviews = await _reviewRepository.GetAllAsync(r =>
            r.ContractId == request.ContractId && r.ReviewerId == request.ReviewerId);

        if (existingReviews.Any())
            throw new Exception("You have already submitted a review for this contract.");

        var review = new Review
        {
            Id = Guid.NewGuid(),
            ContractId = request.ContractId,
            ReviewerId = request.ReviewerId,
            RevieweeId = request.RevieweeId,
            Rating = request.Rating,
            Comment = request.Comment,
            CreatedDate = DateTime.UtcNow
        };

        await _reviewRepository.AddAsync(review);
        return review.Id;
    }
}
