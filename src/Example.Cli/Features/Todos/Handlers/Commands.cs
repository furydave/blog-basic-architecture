using Example.Cli.Features.Todos.Constants;
using Example.Cli.Features.Todos.Models;
using Example.Product.Features.Todos.Repositories.Implementation;
using System.CommandLine;

namespace Example.Cli.Features.Todos.Handlers;

internal static class Commands
{
    /// <summary>
    /// Creates a new todo item and adds it to the repository.
    /// </summary>
    /// <param name="result">The parse result containing the command-line options.</param>
    /// <returns>The exit code of the command.</returns>
    internal static int Create(ParseResult result)
    {
        var title = result.GetValue<string>(OptionNames.Title)!;
        var description = result.GetValue<string>(OptionNames.Description)!;
        var todo = new TodoRequestModel(title, description);
        var repository = new NoddyTodoRepository();
        var id = repository.Add(todo);

        if(id is null)
        {
            result.InvocationConfiguration.Error.WriteLine("Failed to create todo.");
            return 1;
        }

        result.InvocationConfiguration.Output.WriteLine($"Todo created: {id}");
        return 0;
    }
}
