using CommentActivityLog.Application.DTOs.ActivityLog;
using FluentValidation;

namespace CommentActivityLog.Application.Validations.ActivityLog;

public class ActivityLogDtoValidation : AbstractValidator<ActivityLogDto>
{
    public ActivityLogDtoValidation()
    {
        RuleFor(x => x)
            .Must(x => x.from_date <= x.to_date)
            .When(x => x.from_date.HasValue && x.to_date.HasValue)
            .WithMessage("تاریخ شروع باید کوچکتر یا مساوی تاریخ پایان باشد");
    }
}