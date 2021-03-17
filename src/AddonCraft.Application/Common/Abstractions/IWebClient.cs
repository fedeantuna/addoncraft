using System;
using System.Threading.Tasks;

namespace AddonCraft.Application.Common.Abstractions
{
    /// <summary>
    /// Defines a contract that allows abstraction from <see cref="System.Net.WebClient"/>.
    /// </summary>
    public interface IWebClient : IDisposable
    {
        /// <summary>
        /// Downloads the resource as a <see cref="Byte"/> array from the URI specified as an asynchronous operation using a task object.
        /// </summary>
        /// <param name="address">The URI of the resource to download.</param>
        /// <returns>The task object representing the asynchronous operation. The <see cref="Task"/> property on the task object returns a <see cref="Byte"/> array containing the downloaded resource.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="address"/> parameter is null.</exception>
        /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and <paramref name="address"/> is invalid. -or- An error occurred while downloading the resource.</exception>
        Task<Byte[]> DownloadDataTaskAsync(String address);
    }
}