using AddonCraft.Application.Common.Abstractions;
using AddonCraft.Application.Common.Abstractions.Factories;

namespace AddonCraft.Infrastructure.Abstractions.Factories
{
    /// <inheritdoc/>
    /// <summary>
    /// Factory for <see cref="IWebClient"/> type.
    /// </summary>
    public class SystemWebClientFactory : ISystemWebClientFactory
    {
        public IWebClient Create() => new SystemWebClient();
    }
}