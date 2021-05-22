namespace spectbug.Commands
{
    using Spectre.Console;
    using Spectre.Console.Cli;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    public class RepeatedPrintCmd : Command<RepeatedPrintCmd.Settings>
    {
        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            AnsiConsole.WriteLine(nameof(RepeatedPrintCmd));
            AnsiConsole.WriteLine($"Message: {settings.Message}");
            AnsiConsole.WriteLine($"Repeat: {settings.Repeat}");
            return 0;
        }

        public class Settings : PrintBaseSettings
        {
            [CommandOption("-r|--repeat <REPEAT>")]
            [Description("How many times to repeat the message")]
            public int Repeat { get; set; }
        }
    }
}
