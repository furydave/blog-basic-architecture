using Example.Product.Features.Todos.Repositories.Interfaces;

namespace Example.Product.Features.Todos.Repositories.Models;

public class Todo : ITodo
{
    public required Guid Id { get; init; }

    public required string Title { get; init; }

    public required string Description { get; init; }
}
