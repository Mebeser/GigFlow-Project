using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class ReviewRepository : EfRepositoryBase<Review, GigFlowDbContext>, IReviewRepository
{
    public ReviewRepository(GigFlowDbContext context) : base(context)
    {
    }
}
