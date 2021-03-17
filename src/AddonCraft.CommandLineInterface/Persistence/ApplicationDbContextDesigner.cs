using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AddonCraft.Application.Common.Services;
using AddonCraft.Domain.Services;
using AddonCraft.Infrastructure.Persistence;
using AddonCraft.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddonCraft.CommandLineInterface.Persistence
{
    // ExcludeFromCodeCoverage: There is no value in testing this.
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContextDesigner : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(String[] args)
        {
            const String appSettingsFile = "appsettings.json";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appSettingsFile, optional: false, reloadOnChange: false);
            var configuration = (IConfiguration)builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    soa => soa.MigrationsAssembly(typeof(Program).Assembly.FullName));

            return new ApplicationDbContext(optionsBuilder.Options, null, null);
        }
    }
}