using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using AddonCraft.CommandLineInterface.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AddonCraft.CommandLineInterface
{
    // ExcludeFromCodeCoverage: There is no value in testing this.
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        static Program()
        {
            Startup.ConfigureServices().BuildServiceProvider();
        }

        public static async Task<Int32> Main(String[] args)
        {
            var rootCommand = new RootCommand("AddonCraft")
            {
                new Command("install", "install an addon or addons to World of Warcraft")
                {
                    new Argument<String[]>("package-names", "packages to install"),
                    new Option<String>(new[] {"--release", "-r"}, () => "latest-stable", "specify the release version for the addon"),
                    new Option<String>(new[] {"--game-flavor", "-g"}, () => "retail", "specify the game flavor (retail or classic)")
                }.WithDefaultHandler(),
                new Command("list", "list installed addons")
                {
                    new Option<String>(new[] {"--game-flavor", "-g"}, () => "retail", "specify the game flavor (retail or classic)")
                }.WithDefaultHandler(),
                new Command("upgrade", "upgrade an addon or addons on World of Warcraft")
                {
                    new Argument<String[]>("package-names", Array.Empty<String>, "packages to upgrade"),
                    new Option<String>(new[] {"--release", "-r"}, () => "latest-stable", "specify the release version for the addon"),
                    new Option<String>(new[] {"--game-flavor", "-g"}, () => "retail", "specify the game flavor (retail or classic)")
                }.WithDefaultHandler(),
                new Command("remove", "remove an addon or addons from World of Warcraft")
                {
                    new Argument<String[]>("package-names", "packages to remove"),
                    new Option<String>(new[] {"--game-flavor", "-g"}, () => "retail", "specify the game flavor (retail or classic)")
                }.WithDefaultHandler(),
            };

            return await rootCommand.InvokeAsync(args);
        }
    }
}