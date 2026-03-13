using AutoMapper;
using GigFlow.Application.Features.Reviews.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByContract;

public class GetReviewsByContractQueryHandler : IRequestHandler<GetReviewsByContractQuery, List<GetReviewDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public GetReviewsByContractQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<List<GetReviewDto>> Handle(GetReviewsByContractQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetAllAsync(r => r.ContractId == request.ContractId);
        return _mapper.Map<List<GetReviewDto>>(reviews.OrderByDescending(r => r.CreatedDate).ToList());
    }
}
