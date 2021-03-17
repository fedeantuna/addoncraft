using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AddonCraft.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AddonCraft.Application
{
    /// <summary>
    /// Provides the Application Dependency Injection.
    /// </summary>
    // ExcludeFromCodeCoverage: There is no value in testing this and it is extremely hard to test.
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the corresponding services for the application layer.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(executingAssembly);
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddMediatR(executingAssembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}