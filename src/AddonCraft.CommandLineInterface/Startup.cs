using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AddonCraft.Application;
using AddonCraft.Infrastructure;
using AddonCraft.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddonCraft.CommandLineInterface
{
    // ExcludeFromCodeCoverage: There is no value in testing this.
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            const String appSettingsFile = "appsettings.json";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appSettingsFile, optional: false, reloadOnChange: false);
            var configuration = (IConfiguration)builder.Build();

            services.AddApplication();
            services.AddInfrastructure(configuration);

            services.AddSingleton(configuration);

            return services;
        }
    }
}