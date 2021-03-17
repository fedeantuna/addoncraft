namespace AddonCraft.Application.Common.Abstractions.Factories
{
    /// <summary>
    /// Defines a contract for the <see cref="IWebClient"/> Factory.
    /// </summary>
    public interface ISystemWebClientFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IWebClient"/> type.
        /// </summary>
        /// <returns>A new instance of the <see cref="IWebClient"/> type.</returns>
        IWebClient Create();
    }
}