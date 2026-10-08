using Example.Api.Features.Todos.Constants;
using Example.Api.Features.Todos.Models;
using Example.Product.Features.Todos.Repositories.Interfaces;

namespace Example.Api.Features.Todos.Controllers;

internal static class Commands
{
    /// <summary>
    /// Creates a new todo item and adds it to the repository.
    /// </summary>
    /// <param name="todo">The todo item to create.</param>
    /// <param name="repository">The repository to add the todo item to.</param>
    /// <returns>The result of the create operation.</returns>
    internal static IResult Create(TodoRequestModel todo, ITodoRepository repository)
    {
        var id = repository.Add(todo);
        return id is null ? Results.BadRequest() : Results.CreatedAtRoute(RouteNames.GetTodoById, new { id });
    }
}
