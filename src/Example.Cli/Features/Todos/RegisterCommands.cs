using Example.Cli.Features.Todos.Constants;
using Example.Cli.Features.Todos.Handlers;
using Example.Cli.Features.Todos.Validators;
using System.CommandLine;

namespace Example.Cli.Features.Todos;

internal static class RegisterCommands
{
    extension(RootCommand root)
    {
        /// <summary>
        /// Registers the commands related to the Todos feature with the specified root command. This includes commands for listing todos, getting a todo by ID, and creating a new todo.
        /// </summary>
        internal void RegisterTodosCommands()
        {
            AddListCommand(root);
            AddGetByIdCommand(root);
            AddCreateTodoCommand(root);
        }

        private void AddListCommand()
        {
            var command = new Command("list-todos", "Lists all todos as a JSON array.");
            command.SetAction(Queries.List);
            root.Subcommands.Add(command);
        }

        private void AddGetByIdCommand()
        {
            var command = new Command("get-todo", $"Gets the todo with the supplied {OptionNames.Id}.");

            var idOption = new Option<Guid>(OptionNames.Id)
            {
                Description = "The ID of the todo to get. Used with get-todo.",
                Required = true
            };

            command.Options.Add(idOption);

            command.SetAction(Queries.GetById);

            root.Subcommands.Add(command);
        }

        private void AddCreateTodoCommand()
        {
            var command = new Command("add-todo", $"Adds a todo with the supplied {OptionNames.Title} and {OptionNames.Description}.");
            var titleOption = new Option<string>(OptionNames.Title)
            {
                Description = "The title of the todo to add. Used with add-todo.",
                Required = true
            };
            var descriptionOption = new Option<string>(OptionNames.Description)
            {
                Description = "The description of the todo to add. Used with add-todo.",
                Required = true
            };

            titleOption.AddStringLengthValidator(100);
            descriptionOption.AddStringLengthValidator(500);
            
            command.Options.Add(titleOption);
            command.Options.Add(descriptionOption);

            command.SetAction(Commands.Create);
            
            root.Subcommands.Add(command);
        }
    }
}
