using System.Net;
using AddonCraft.Application.Common.Abstractions;

namespace AddonCraft.Infrastructure.Abstractions
{
    /// <inheritdoc cref="WebClient"/>
    /// <summary>
    /// An abstraction from <see cref="WebClient"/>.
    /// </summary>
    public class SystemWebClient : WebClient, IWebClient
    {
    }
}