using CommentActivityLog.Application.DTOs.Comment;
using FluentValidation;

namespace CommentActivityLog.Application.Validations.Comment;

public class UpdateCommentDtoValidation : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidation()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .WithMessage("task id must be greater than 0.");

        RuleFor(p => p.Content)
            .NotEmpty()
            .WithMessage("content is required.")
            .MaximumLength(500)
            .WithMessage("content must be less than 500 characters")
            .MinimumLength(10)
            .WithMessage("content must be greater than 10 characters");
    }
}