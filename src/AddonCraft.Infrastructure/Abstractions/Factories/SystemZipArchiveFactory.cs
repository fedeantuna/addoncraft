using System.IO;
using System.IO.Compression;
using AddonCraft.Application.Common.Abstractions;
using AddonCraft.Application.Common.Abstractions.Factories;

namespace AddonCraft.Infrastructure.Abstractions.Factories
{
    /// <inheritdoc/>
    /// <summary>
    /// Factory for <see cref="IZipArchive"/> type.
    /// </summary>
    public class SystemZipArchiveFactory : ISystemZipArchiveFactory
    {
        public IZipArchive Create(Stream stream, ZipArchiveMode zipArchiveMode) => new SystemZipArchive(stream, zipArchiveMode);
    }
}