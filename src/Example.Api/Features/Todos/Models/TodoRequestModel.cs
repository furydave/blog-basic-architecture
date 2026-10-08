using Example.Product.Features.Todos.Repositories.Interfaces;

namespace Example.Api.Features.Todos.Models;

public class TodoRequestModel : ITodo
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
