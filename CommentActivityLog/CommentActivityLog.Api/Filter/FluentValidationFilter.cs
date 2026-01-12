using CommentActivityLog.Domain.Common;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CommentActivityLog.Api.Filter;

public class FluentValidationFilter : IActionFilter
{
    private readonly IServiceProvider _serviceProvider;
    public FluentValidationFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument == null)
                continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
            var validator = _serviceProvider.GetService(validatorType) as IValidator;

            if (validator == null)
                continue;

            var validationContext = new ValidationContext<object>(argument);
            var result = validator.Validate(validationContext);

            if (!result.IsValid)
            {
                var errors = result.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => new
                    {
                        Field = g.Key,
                        Messages = string.Join(',',g.Select(e => e.ErrorMessage).ToList())
                    })
                    .ToList();

                context.Result = new BadRequestObjectResult(new Result
                {
                    IsSuccess = false,
                    Message = string.Join(',',errors),
                });

                return;
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}

