using System;
using System.Threading.Tasks;

namespace AddonCraft.Application.Common.Services
{
    /// <summary>
    /// Defines a contract for communication over the network.
    /// </summary>
    public interface INetworkService
    {
        /// <summary>
        /// Downloads the resource as a <see cref="byte"/> array from the URI specified as an asynchronous operation using a task object.
        /// </summary>
        /// <param name="address">The URI of the resource to download.</param>
        /// <returns>The task object representing the asynchronous operation. The <see cref="Task"/> property on the task object returns a <see cref="byte"/> array containing the downloaded resource.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="address"/> parameter is null.</exception>
        /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and <paramref name="address"/> is invalid. -or- An error occurred while downloading the resource.</exception>
        Task<Byte[]> DownloadFileAsync(String address);
    }
}