using FluentValidation.TestHelper;
using GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;

namespace GigFlow.Tests;

public class CreateJobPostingCommandValidatorTests
{
    private readonly CreateJobPostingCommandValidator _validator = new();

    [Fact]
    public void Title_WhenEmpty_ShouldHaveError()
    {
        var command = new CreateJobPostingCommand { Title = "" };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public void BudgetMax_WhenLessThanBudgetMind_ShouldHaveError()
    {
        var command = new CreateJobPostingCommand
        {
            BudgetMin = 5000,
            BudgetMax = 1000
        };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.BudgetMax);
    }

    [Fact]
    public void DeadLine_WhenBeforeDate_ShouldHaveError()
    {
        var command = new CreateJobPostingCommand {Deadline = DateTime.Now.AddDays(-1)};
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Deadline);
    }

    [Fact]
    public void SkıllIds_WhenEmpty_ShouldHaveError()
    {
        var command = new CreateJobPostingCommand { SkillIds = null };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.SkillIds);
    }
}