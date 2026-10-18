using System.CommandLine;
using System.Reflection;

namespace CritKit.CommandLine.Commands;

public static class EntrypointCommand
{
    static EntrypointCommand()
    {
        Command = new RootCommand("Welcome to the CritKit Dungeons and Dragons CLI");
        
        Command.SetAction(result =>
        {
            Console.WriteLine("Welcome to the CritKit!");
            Console.WriteLine("Roll dice, look up sells, explore the rules.");
            Console.WriteLine("Use --help to see available commands.");
        });
        
    }
    
    public static readonly RootCommand Command;
}