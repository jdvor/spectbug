namespace spectbug.Commands
{
    using Spectre.Console.Cli;
    using System.ComponentModel;

    public abstract class PrintBaseSettings : CommandSettings
    {
        [CommandOption("-m|--message <MESSAGE>")]
        [Description("Message to print")]
        public string Message { get; set; } = string.Empty;
    }
}
