namespace spectbug
{
    using Microsoft.Extensions.DependencyInjection;
    using spectbug.Commands;
    using Spectre.Console.Cli;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandApp(BootstrapServices());
            app.Configure(opts =>
            {
                opts.SetApplicationName("spectbug");
                opts.SetApplicationVersion("1.0");

                //opts.ValidateExamples();
                // => Spectre.Console.Cli.CommandConfigurationException: 'Validation of examples failed.'
                // Unknown option 'm'
                // but 'm' is defined at PrintBaseSettings:L8

                opts.AddBranch<PrintBaseSettings>("print", p =>
                {
                    p.SetDescription("Print message");

                    p.AddCommand<RepeatedPrintCmd>("repeated")
                        .WithAlias("repeat")
                        .WithDescription("Print message several times")
                        .WithExample(new[] { "print", "repeated", "-m", "Lorem ipsum", "-r", "5" });

                    p.AddCommand<DecoratedPrintCmd>("decorated")
                        .WithAlias("decor")
                        .WithDescription("Print with foo flavor")
                        .WithExample(new[] { "print", "decorated", "-m", "Lorem ipsum", "--with-foo" });
                });
            });

            app.Run(args);
        }

        private static TypeRegistrar BootstrapServices()
        {
            var services = new ServiceCollection();

            //services.AddSingleton<RepeatedPrintCmd.Settings>(); // why needed?
            //services.AddSingleton<RepeatedPrintCmd>(); // why needed?

            services.AddSingleton<IFooService, FooService>();

            //services.AddSingleton<DecoratedPrintCmd.Settings>(); // why needed?
            //services.AddSingleton<DecoratedPrintCmd>(); // why needed?

            return new TypeRegistrar(services);
        }
    }
}
