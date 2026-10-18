// See https://aka.ms/new-console-template for more information

using CritKit.CommandLine.Commands;

var rootCommand = EntrypointCommand.Command;

rootCommand.Subcommands.Add(DiceRollCommand.Command);

var parseResult = rootCommand.Parse(args);

return parseResult.Invoke();
