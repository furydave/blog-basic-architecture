using Example.Product.Features.Todos.Repositories.Models;

namespace Example.Product.Features.Todos.Repositories.Interfaces;

public interface ITodoRepository
{
    /// <summary>
    /// Lists all todo items in the repository.
    /// </summary>
    /// <returns>A list of all todo items.</returns>
    List<Todo> List();

    /// <summary>
    /// Adds a new todo item to the repository.
    /// </summary>
    /// <param name="model">The todo item to add.</param>
    /// <returns>The ID of the newly added todo item, or null if the addition failed.</returns>
    Guid? Add(ITodo model);

    /// <summary>
    /// Gets a todo item by its ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the todo item to retrieve.</param>
    /// <returns>The todo item with the specified ID, or null if not found.</returns>
    Todo? GetById(Guid id);
}
