using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using AddonCraft.Infrastructure.Abstractions;
using AddonCraft.Infrastructure.Abstractions.Factories;
using Xunit;

namespace AddonCraft.Infrastructure.UnitTests.Abstractions.Factories
{
    [ExcludeFromCodeCoverage]
    public class SystemZipArchiveFactoryTests
    {
        private readonly SystemZipArchiveFactory _sut;

        public SystemZipArchiveFactoryTests()
        {
            this._sut = new SystemZipArchiveFactory();
        }

        [Fact]
        public void Create_ReturnsSystemZipArchive()
        {
            // Arrange
            const String rootEntryA = "test_dir_a";
            const String rootEntryB = "test_dir_b";
            const String rootEntryC = "test_dir_c";
            var rootEntryBba = $"{rootEntryB}/test_dir_ba";
            var rootEntryCca = $"{rootEntryC}/test_dir_ca";
            var rootEntryCcb = $"{rootEntryC}/test_dir_cb";
            var memoryStream = new MemoryStream();
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, leaveOpen: true))
            {
                archive.CreateEntry(rootEntryA);
                archive.CreateEntry(rootEntryB);
                archive.CreateEntry(rootEntryBba);
                archive.CreateEntry(rootEntryCca);
                archive.CreateEntry(rootEntryCcb);
            }

            // Act
            var result = this._sut.Create(memoryStream, ZipArchiveMode.Read);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SystemZipArchive>(result);
        }
    }
}