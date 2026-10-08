using Example.Api.Features.Todos.Models;
using FluentValidation;

namespace Example.Api.Features.Todos.Validators;

public class TodoRequestModelValidator : AbstractValidator<TodoRequestModel>
{
    public TodoRequestModelValidator()
    {
        /// <summary>
        /// Validates the Title property of the TodoRequestModel.
        /// </summary>
        RuleFor(model => model.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        /// <summary>
        /// Validates the Description property of the TodoRequestModel.
        /// </summary>
        RuleFor(model => model.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}
