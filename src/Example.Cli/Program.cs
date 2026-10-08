using Example.Cli.Features.Todos;
using System.CommandLine;

var rootCommand = new RootCommand("Example todos CLI.");

rootCommand.RegisterTodosCommands();

return rootCommand.Parse(args).Invoke();
