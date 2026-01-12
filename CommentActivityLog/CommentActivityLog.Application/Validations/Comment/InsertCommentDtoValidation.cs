using CommentActivityLog.Application.DTOs.Comment;
using FluentValidation;

namespace CommentActivityLog.Application.Validations.Comment;

public class InsertCommentDtoValidation : AbstractValidator<InsertCommentDto>
{
    public InsertCommentDtoValidation()
    {
        RuleFor(p => p.Content)
            .NotEmpty()
            .WithMessage("content is required.")
            .MaximumLength(500)
            .WithMessage("content must be less than 500 characters")
            .MinimumLength(10)
            .WithMessage("content must be greater than 10 characters");

        RuleFor(p => p.TaskId)
            .GreaterThan(0)
            .WithMessage("task id must be greater than 0.");
    }
}
