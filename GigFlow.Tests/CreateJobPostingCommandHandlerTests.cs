using GigFlow.Domain.Entities;
using GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;
using GigFlow.Application.Repositories;

using Moq;
namespace GigFlow.Tests;

public class CreateJobPostingCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnGuid_WhenJobPostingCreated()
    {
        
        var mockRepo = new Mock<IJobPostingRepository>();
        var handler = new CreateJobPostingCommandHandler(mockRepo.Object);

        var command = new CreateJobPostingCommand
        {
            Title = "Test Job",
            Description = "Test Description",
            CategoryId = Guid.NewGuid(),
            BudgetMin = 1000,
            BudgetMax = 5000,
            ClientId = Guid.NewGuid(),
            Deadline = DateTime.UtcNow.AddDays(30),
            SkillIds = new List<Guid>()
        };
        var result = await handler.Handle(command, CancellationToken.None);
        
        //Assert
        Assert.NotEqual(Guid.Empty,result);
        mockRepo.Verify(x=> x.AddAsync(It.IsAny<JobPosting>()), Times.Once);
    }

   
}