using Example.Product.Features.Todos.Repositories.Interfaces;

namespace Example.Cli.Features.Todos.Models;

public record TodoRequestModel(string Title, string Description) : ITodo;
