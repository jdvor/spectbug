namespace spectbug.Commands
{
    using Spectre.Console;
    using Spectre.Console.Cli;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    public class DecoratedPrintCmd : Command<DecoratedPrintCmd.Settings>
    {
        private readonly IFooService fooSrv;

        public DecoratedPrintCmd(IFooService fooSrv)
        {
            this.fooSrv = fooSrv;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            AnsiConsole.WriteLine(nameof(DecoratedPrintCmd));
            AnsiConsole.WriteLine($"Message: {settings.Message}");

            if (settings.WithFoo)
                AnsiConsole.WriteLine($"Foo: {fooSrv.GetFoo()}");

            return 0;
        }

        public class Settings : PrintBaseSettings
        {
            [CommandOption("-f|--with-foo")]
            [Description("with foo")]
            public bool WithFoo { get; set; }
        }
    }
}
