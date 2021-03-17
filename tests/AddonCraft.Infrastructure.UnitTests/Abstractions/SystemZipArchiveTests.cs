using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Linq;
using AddonCraft.Infrastructure.Abstractions;
using Xunit;

namespace AddonCraft.Infrastructure.UnitTests.Abstractions
{
    [ExcludeFromCodeCoverage]
    public class SystemZipArchiveTests
    {
        [Fact]
        public void GetRootEntries_ReturnsDistinctRootEntries()
        {
            // Arrange
            const String rootEntryA = "test_dir_a";
            const String rootEntryB = "test_dir_b";
            const String rootEntryC = "test_dir_c";
            var rootEntryBba = $"{rootEntryB}/test_dir_ba";
            var rootEntryCca = $"{rootEntryC}/test_dir_ca";
            var rootEntryCcb = $"{rootEntryC}/test_dir_cb";
            var memoryStream = new MemoryStream();
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                archive.CreateEntry(rootEntryA);
                archive.CreateEntry(rootEntryB);
                archive.CreateEntry(rootEntryBba);
                archive.CreateEntry(rootEntryCca);
                archive.CreateEntry(rootEntryCcb);
            }

            var sut = new SystemZipArchive(memoryStream, ZipArchiveMode.Read);

            var expectedEntries = new[]
            {
                rootEntryA,
                rootEntryB,
                rootEntryC
            };

            // Act
            var result = sut.GetRootEntries().OrderBy(re => re).ToList();

            // Assert
            Assert.Collection(result,
                item => Assert.Equal(expectedEntries[0], item),
                item => Assert.Equal(expectedEntries[1], item),
                item => Assert.Equal(expectedEntries[2], item));
            
            memoryStream.Dispose();
        }
    }
}