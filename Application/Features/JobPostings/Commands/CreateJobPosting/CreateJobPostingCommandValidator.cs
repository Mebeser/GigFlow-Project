using FluentValidation;

namespace GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;

public class CreateJobPostingCommandValidator : AbstractValidator<CreateJobPostingCommand>
{
    public CreateJobPostingCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("İlan başlığı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("İlan başlığı en fazla 200 karakter olabilir.");
            
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("İlan açıklaması boş bırakılamaz.")
            .MaximumLength(5000).WithMessage("İlan açıklaması en fazla 5000 karakter olabilir.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Lütfen geçerli bir kategori seçiniz.");

        RuleFor(x => x.BudgetMin)
            .GreaterThanOrEqualTo(0).WithMessage("Lütfen geçerli bir bütçe aralığı giriniz.");

        RuleFor(x => x.BudgetMax)
            .GreaterThanOrEqualTo(x => x.BudgetMin).WithMessage("Maksimum bütçe, minimum bütçe tutarından az olamaz.");

        RuleFor(x => x.Deadline)
            .Must(deadline => !deadline.HasValue || deadline.Value > DateTime.UtcNow)
            .WithMessage("Son başvuru tarihi geçmiş bir zaman olamaz.");

        RuleFor(x => x.SkillIds)
            .Must(skills => skills != null && skills.Count >= 1 && skills.Count <= 10)
            .WithMessage("Lütfen ilan için en az 1, en fazla 10 adet yetenek seçiniz.");
    }
}
