using Example.Api.Features.Todos.Models;
using FluentValidation;

namespace Example.Api.Features.Todos.Filters;

internal class TodoRequestModelValidationFilter(IValidator<TodoRequestModel> validator) : IEndpointFilter
{
    /// <summary>
    /// Validates the TodoRequestModel and returns a validation problem if the model is invalid.
    /// </summary>
    /// <param name="context">The context for the endpoint filter invocation.</param>
    /// <param name="next">The delegate representing the next filter or endpoint in the pipeline.</param>
    /// <returns>The result of the validation operation.</returns>
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var model = context.Arguments.OfType<TodoRequestModel>().FirstOrDefault();

        if(model is null)
        {
            return next(context);
        }

        var validationResult = validator.Validate(model);

        if(validationResult.IsValid)
        {
            return next(context);
        }

        return ValueTask.FromResult<object?>(Results.ValidationProblem(validationResult.ToDictionary()));
    }
}
