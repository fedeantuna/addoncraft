using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddonCraft.CommandLineInterface
{
    // ExcludeFromCodeCoverage: There is no value in testing this.
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        // private const String _connectionStringName = "Default";
        private const String AppSettingsFile = "appsettings.json";

        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppSettingsFile, optional: false, reloadOnChange: false);
            var configuration = (IConfiguration)builder.Build();

            services.AddSingleton(configuration);

            return services;
        }
    }
}