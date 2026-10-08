using Example.Api.Features.Todos.Constants;
using Example.Api.Features.Todos.Controllers;
using Example.Api.Features.Todos.Filters;
using Example.Api.Features.Todos.Models;
using Example.Api.Features.Todos.Validators;
using Example.Product.Features.Todos.Repositories.Implementation;
using Example.Product.Features.Todos.Repositories.Interfaces;
using FluentValidation;

namespace Example.Api.Features.Todos;

internal static class ComposeDependencies
{
    extension(WebApplication endpoints)
    {
        /// <summary>
        /// Registers the endpoints for the Todos feature.
        /// </summary>
        internal void RegisterTodosFeature()
        {
            endpoints
                .MapGet(Routes.List, Queries.List)
                .WithName(RouteNames.ListTodos)
                ;

            endpoints
                .MapGet(Routes.GetById, Queries.GetById)
                .WithName(RouteNames.GetTodoById)
                ;

            endpoints
                .MapPost(Routes.Add, Commands.Create)
                .WithName(RouteNames.AddTodo)
                .AddEndpointFilter<TodoRequestModelValidationFilter>()
                ;
        }
    }

    extension(IServiceCollection services)
    {
        /// <summary>
        /// Registers the dependencies for the Todos feature.
        /// </summary>
        internal void RegisterTodosFeatureDependencies()
        {
            services.AddSingleton<IValidator<TodoRequestModel>, TodoRequestModelValidator>();
            services.AddSingleton<ITodoRepository, NoddyTodoRepository>();
        }
    }
}
