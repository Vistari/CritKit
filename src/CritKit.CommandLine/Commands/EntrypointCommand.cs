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
            var tagMargin = (Console.WindowWidth - TagLine.Length) / 2;
            
            WriteCenterLines(SplashArtTextLines);
            WriteCenterLines([TagLine]);

            Console.WriteLine("\n\nRoll dice, look up spells, explore the rules.");
            Console.WriteLine("\nUse --help to see available commands.\n");
        });
    }
    
    public static readonly RootCommand Command;

    private static string[] SplashArtTextLines =>
        [
        @"<+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+>",
        @" |      __        ██████╗██████╗ ██╗████████╗   ██╗  ██╗██╗████████╗ | ",
        @" |    _/  \_     ██╔════╝██╔══██╗██║╚══██╔══╝   ██║ ██╔╝██║╚══██╔══╝ | ",
        @" |   / \  / \    ██║     ██████╔╝██║   ██║      █████╔╝ ██║   ██║    | ",
        @" |  |  \20/  |   ██║     ██╔══██╗██║   ██║      ██╔═██╗ ██║   ██║    | ",
        @" |   \_/  \_/    ╚██████╗██║  ██║██║   ██║      ██║  ██╗██║   ██║    | ",
        @" |     \__/       ╚═════╝╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝  ╚═╝╚═╝   ╚═╝    | ",
        @"<+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+>"
        ];

    private static string TagLine => "-- For when sudo isn't enough magic. --";
    
    static void WriteCenterLines(params string[] lines)
    {
        var verticalStart = (Console.WindowHeight - lines.Length) / 2;

        foreach (var line in lines)
        {
            var horizontalStart = (Console.WindowWidth - line.Length) / 2;
            Console.SetCursorPosition(horizontalStart, Console.CursorTop);
            Console.WriteLine(line);
        }
    }

}