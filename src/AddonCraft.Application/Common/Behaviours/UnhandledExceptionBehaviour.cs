using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AddonCraft.Application.Common.Behaviours
{
    /// <inheritdoc/>
    /// <summary>
    /// Provides the Unhandled Exception Behaviour.
    /// </summary>
    /// <typeparam name="TRequest">Request type.</typeparam>
    /// <typeparam name="TResponse">Response type.</typeparam>
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        /// <summary>
        /// Initializes the Unhandled Exception Behaviour with its dependencies.
        /// </summary>
        /// <param name="logger">The logger dependency.</param>
        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            this._logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                const String errorMessage = "Unhandled Exception for Request {name} {request}";
                var requestName = typeof(TRequest).Name;
                this._logger.LogError(ex, errorMessage, requestName, request);

                throw;
            }
        }
    }
}