using Example.Product.Features.Todos.Repositories.Interfaces;

namespace Example.Api.Features.Todos.Controllers;

internal static class Queries
{
    /// <summary>
    /// Lists all todos from the repository. If there are no todos, it returns a NoContent response.
    /// </summary>
    /// <param name="repository">The repository to retrieve the todos from.</param>
    /// <returns>The result of the list operation.</returns>
    internal static IResult List(ITodoRepository repository)
    {
        var todos = repository.List();
        return todos.Count > 0 ? Results.Ok(todos) : Results.NoContent();
    }

    /// <summary>
    /// Gets a todo item by its ID from the repository. If the todo item is not found, it returns a NotFound response.
    /// </summary>
    /// <param name="id">The ID of the todo item to retrieve.</param>
    /// <param name="repository">The repository to retrieve the todo item from.</param>
    /// <returns>The result of the get operation.</returns>
    internal static IResult GetById(Guid id, ITodoRepository repository)
    {
        var todo = repository.GetById(id);
        return todo is null ? Results.NotFound() : Results.Ok(todo);
    }
}
