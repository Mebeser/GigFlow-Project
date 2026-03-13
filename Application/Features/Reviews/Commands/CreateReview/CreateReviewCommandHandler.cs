using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IContractRepository _contractRepository;
    private readonly IFreelancerProfileRepository _freelancerProfileRepository;

    public CreateReviewCommandHandler(
        IReviewRepository reviewRepository,
        IContractRepository contractRepository,
        IFreelancerProfileRepository freelancerProfileRepository)
    {
        _reviewRepository = reviewRepository;
        _contractRepository = contractRepository;
        _freelancerProfileRepository = freelancerProfileRepository;
    }

    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetByIdAsync(request.ContractId);
        if (contract == null || contract.Status != ContractStatus.Completed)
        {
            throw new Exception("Yalnızca tamamlanmış işler için değerlendirme yapılabilir.");
        }

        var existingReviews = await _reviewRepository.GetAllAsync(r =>
            r.ContractId == request.ContractId && r.ReviewerId == request.ReviewerId);

        if (existingReviews.Any())
        {
            throw new Exception("Bu iş için zaten bir değerlendirme yapılmış.");
        }

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

        // Ortalama puanı tekrar hesaplıyoruz
        var allReviews = await _reviewRepository.GetAllAsync(r => r.RevieweeId == request.RevieweeId);
        if (allReviews.Any())
        {
            var average = (decimal)allReviews.Average(r => r.Rating);
            var profiles = await _freelancerProfileRepository.GetAllAsync(p => p.UserId == request.RevieweeId);
            var profile = profiles.FirstOrDefault();
            
            if (profile != null)
            {
                profile.AverageRating = average;
                await _freelancerProfileRepository.UpdateAsync(profile);
            }
        }

        return review.Id;
    }
}
