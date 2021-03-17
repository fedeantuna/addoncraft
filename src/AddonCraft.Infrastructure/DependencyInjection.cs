using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Application.Common.Persistence;
using AddonCraft.Application.Common.Services;
using AddonCraft.Domain.Services;
using AddonCraft.Infrastructure.Persistence;
using AddonCraft.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddonCraft.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IApplicationDbContext>(sp => sp.GetService<ApplicationDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddSingleton<ITimeService, TimeService>();
            
            return services;
        }
    }
}