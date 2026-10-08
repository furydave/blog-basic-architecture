namespace Example.Api.Features.Todos.Constants;

/// <summary>
/// Defines the routes for the Todos feature.
/// </summary>
internal static class Routes
{
    private const string Root = "/todos";

    internal const string List = Root;

    internal const string GetById = Root + "/{id:guid}";

    internal const string Add = Root;
}
