using Example.Product.Features.Todos.Repositories.Interfaces;
using Example.Product.Features.Todos.Repositories.Models;
using System.Collections.Concurrent;

namespace Example.Product.Features.Todos.Repositories.Implementation;

public class NoddyTodoRepository : ITodoRepository
{
    private static readonly ConcurrentBag<Todo> _todos;

    static NoddyTodoRepository()
    {
        _todos =
        [
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-891c-000000000001"),
                Title = "Todo 1",
                Description = "Description 1"
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-891c-000000000002"),
                Title = "Todo 2",
                Description = "Description 2"
            }
        ];
    }

        
    public List<Todo> List() => [.. _todos.OrderBy(todo => todo.Id)];

    /// <inheritdoc cref="ITodoRepository.Add"/>
    public Guid? Add(ITodo model)
    {
        var todo = new Todo
        {
            Id = Guid.CreateVersion7(),
            Title = model.Title,
            Description = model.Description
        };
        _todos.Add(todo);
        return todo.Id;
    }
    
    /// <inheritdoc cref="ITodoRepository.GetById(Guid)"/>
    public Todo? GetById(Guid id) => _todos.FirstOrDefault(todo => todo.Id == id);
}
