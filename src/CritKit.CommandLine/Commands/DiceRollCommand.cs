using System.CommandLine;
using System.Reflection;

namespace CritKit.CommandLine.Commands;

public static class DiceRollCommand
{
    static DiceRollCommand()
    {
        Command = new Command("roll", "Roll some dice");

        Command.Arguments.Add(DiceArgument);

        Command.Options.Add(VerboseOption);

        Command.SetAction(result =>
        {
            var dice = result.GetValue<string>(DiceArgument.Name);

            if (string.IsNullOrWhiteSpace(dice))
            {
                throw new ArgumentException("Invalid 'dice' argument, it must contain at least 1 dice");
            }

            if (result.GetValue(VerboseOption))
            {
                Console.WriteLine($"Rolling {dice}");
            }

            var diceRollParts = SplitDiceInput(dice);
        });
    }

    public static readonly Command Command;

    private static string[] EquationSeparators = ["+", "-"];

    private static readonly Argument<string> DiceArgument = new("dice")
    {
        Description =
            "Dice notation, e.g. d20 or 2d6. Simple equations using '+' and/or '-' such as 2d20+1d6-3 are also supported."
    };

    private static readonly Option<bool> VerboseOption = new("--verbose", "-v")
    {
        Description = "Displays each individual roll result rather than just the total."
    };

    private static Span<Range> SplitDiceInput(string diceInput)
    {
        Span<Range> diceRolls = [];
        diceInput.SplitAny(diceRolls, EquationSeparators, StringSplitOptions.RemoveEmptyEntries);

        return diceRolls;
    }
}