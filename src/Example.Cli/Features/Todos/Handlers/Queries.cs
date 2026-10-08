using Example.Cli.Features.Todos.Constants;
using Example.Product.Features.Todos.Repositories.Implementation;
using System.CommandLine;
using System.Text.Json;

namespace Example.Cli.Features.Todos.Handlers;

internal static class Queries
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web) { WriteIndented = true };

    /// <summary>
    /// Lists all todo items in the repository and outputs them in JSON format.
    /// </summary>
    /// <param name="result">The parse result containing the command-line options.</param>
    /// <returns>The exit code of the command.</returns>
    internal static int List(ParseResult result)
    {
        var output = result.InvocationConfiguration.Output;
        var repository = new NoddyTodoRepository();
        var data = repository.List();
        output.WriteLine(JsonSerializer.Serialize(data, JsonOptions));
        return 0;
    }

    /// <summary>
    /// Gets a todo item by its ID from the repository and outputs it in JSON format. If the todo item is not found, it outputs an error message.
    /// </summary>
    /// <param name="result">The parse result containing the command-line options.</param>
    /// <returns>The exit code of the command.</returns>
    internal static int GetById(ParseResult result)
    {
        var id = result.GetValue<Guid>(OptionNames.Id);
        var repository = new NoddyTodoRepository();
        var data = repository.GetById(id);
        if (data is null)
        {
            result.InvocationConfiguration.Error.WriteLine($"No todo with id {id} found.");
            return 1;
        }
        result.InvocationConfiguration.Output.WriteLine(JsonSerializer.Serialize(data, JsonOptions));
        return 0;
    }
}
