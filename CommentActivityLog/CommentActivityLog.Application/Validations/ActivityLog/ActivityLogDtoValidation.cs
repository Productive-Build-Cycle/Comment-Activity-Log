using CommentActivityLog.Application.DTOs.ActivityLog;
using FluentValidation;

namespace CommentActivityLog.Application.Validations.ActivityLog;

public class ActivityLogDtoValidation : AbstractValidator<ActivityLogDto>
{
    public ActivityLogDtoValidation()
    {
        RuleFor(x => x.from_date)
            .Must(BeAValidDate)
            .When(x => x.from_date.HasValue)
            .WithMessage("فرمت تاریخ شروع معتبر نیست");

        RuleFor(x => x.to_date)
            .Must(BeAValidDate)
            .When(x => x.to_date.HasValue)
            .WithMessage("فرمت تاریخ پایان معتبر نیست");

        RuleFor(x => x)
            .Must(x => x.from_date <= x.to_date)
            .When(x => x.from_date.HasValue && x.to_date.HasValue)
            .WithMessage("تاریخ شروع باید کوچکتر یا مساوی تاریخ پایان باشد");
    }

    private bool BeAValidDate(DateTime? date)
    {
        return date.HasValue;
    }
}