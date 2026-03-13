using FluentValidation;

namespace GigFlow.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.ContractId).NotEmpty().WithMessage("Değerlendirilecek sözleşme bulunamadı.");
        RuleFor(x => x.ReviewerId).NotEmpty().WithMessage("Değerlendiren kullanıcı bilgisi eksik.");
        RuleFor(x => x.RevieweeId).NotEmpty().WithMessage("Değerlendirilen kullanıcı bilgisi eksik.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Değerlendirme puanı 1 ile 5 arasında olmalıdır.");

        RuleFor(x => x.Comment)
            .MaximumLength(2000).WithMessage("Yorumunuz en fazla 2000 karakter olabilir.")
            .When(x => x.Comment != null);
    }
}
