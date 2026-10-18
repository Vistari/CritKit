using System.CommandLine;
using System.Reflection;

namespace CritKit.CommandLine.Commands;

public static class DiceRollCommand
{
    static DiceRollCommand()
    {
        Command = new Command("roll", "Roll some dice");

        Command.Arguments.Add(DiceArgument);

        Command.SetAction(result =>
        {
            var dice = result.GetValue<string>(DiceArgument.Name);
            Console.WriteLine($"Rolling {dice}");
        });

    }

    public static readonly Command Command;

    private static Argument<string> DiceArgument => new ("dice")
    {
        Description = "Dice notation, e.g. d20 or 2d6"
    };
}