using AutoMapper;
using GigFlow.Application.Features.Reviews.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByUser;

public class GetReviewsByUserQueryHandler : IRequestHandler<GetReviewsByUserQuery, List<GetReviewDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public GetReviewsByUserQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<List<GetReviewDto>> Handle(GetReviewsByUserQuery request, CancellationToken cancellationToken)
    {
        // Kullanıcının reviewee olduğu değerlendirmeleri getir
        var reviews = await _reviewRepository.GetAllAsync(r => r.RevieweeId == request.UserId);
        return _mapper.Map<List<GetReviewDto>>(reviews.OrderByDescending(r => r.CreatedDate).ToList());
    }
}
