using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AddonCraft.Application.Common.Services;
using AddonCraft.Domain.Entities;
using AddonCraft.Domain.Enums;
using AddonCraft.Domain.Services;
using AddonCraft.Infrastructure.Persistence;
using AddonCraft.Infrastructure.UnitTests.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace AddonCraft.Infrastructure.UnitTests.Persistence
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContextTests
    {
        private readonly Mock<IDomainEventService> _domainEventServiceMock;
        private readonly Mock<ITimeService> _timeServiceMock;

        public ApplicationDbContextTests()
        {
            this._domainEventServiceMock = new Mock<IDomainEventService>();
            this._timeServiceMock = new Mock<ITimeService>();
        }

        [Fact]
        public async Task SaveChangesAsync_SetsCreatedAtDatesAndSavesNewEntries()
        {
            // Arrange
            const String packageAName = "Test Package A";
            const String packageBName = "Test Package B";
            const Int32 metadataAExternalId = 1;
            const Int32 metadataBExternalId = 2;
            var metadataA = new Metadata(metadataAExternalId, packageAName);
            var metadataB = new Metadata(metadataBExternalId, packageBName);

            var now = DateTime.UtcNow;
            this._timeServiceMock.SetupGet(tsm => tsm.UtcNow).Returns(now);

            var sut = this.CreateSut();

            await sut.Metadata.AddAsync(metadataA);
            await sut.Metadata.AddAsync(metadataB);

            const Int32 expectedResult = 2;

            // Act
            var result = await sut.SaveChangesAsync();

            // Arrange
            Assert.Equal(expectedResult, result);
            Assert.Collection(sut.Metadata,
                item => Assert.Equal(now, item.CreatedAt),
                item => Assert.Equal(now, item.CreatedAt));
        }

        [Fact]
        public async Task SaveChangesAsync_SetsLastModifiedDatesAndSavesUpdatedEntries()
        {
            // Arrange
            const String updatedVersion = "1.2.3";
            const String packageName = "Test Package Name";
            const Int32 externalId = 1;
            const String name = "Test Addon Name";
            const String version = "0.1.2";
            var metadata = new Metadata(externalId, packageName);
            var gameVersionFlavor = GameFlavor.Retail;
            var releaseType = ReleaseType.Stable;
            var addon = new Addon(name, version, metadata, gameVersionFlavor, releaseType);

            var before = DateTime.UtcNow;
            this._timeServiceMock.SetupGet(tsm => tsm.UtcNow).Returns(before);

            var sut = this.CreateSut();

            await sut.Addons.AddAsync(addon);
            await sut.SaveChangesAsync();
            var savedAddon = await sut.Addons.FirstOrDefaultAsync(a => a.Id == addon.Id);
            savedAddon.UpdateVersion(updatedVersion);
            sut.Addons.Update(savedAddon);
            var now = DateTime.UtcNow.AddHours(new Random().Next(8));
            this._timeServiceMock.SetupGet(tsm => tsm.UtcNow).Returns(now);

            const Int32 expectedResult = 1;

            // Act
            var result = await sut.SaveChangesAsync();

            // Arrange
            Assert.Single(sut.Addons);
            var updatedAddon = await sut.Addons.SingleAsync();
            Assert.Equal(expectedResult, result);
            Assert.Equal(now, updatedAddon.LastModified);
            Assert.Equal(before, updatedAddon.CreatedAt);
            Assert.Equal(updatedVersion, updatedAddon.Version);
        }

        [Fact]
        public async Task SaveChangesAsync_DispatchesEvents()
        {
            // Arrange
            const String packageName = "Test Package";
            const Int32 metadataExternalId = 1;
            var fakeDomainEventA = new DomainEventMock(this._timeServiceMock.Object);
            var fakeDomainEventB = new DomainEventMock(this._timeServiceMock.Object);
            var metadata = new Metadata(metadataExternalId, packageName);
            metadata.AddDomainEvent(fakeDomainEventA);
            metadata.AddDomainEvent(fakeDomainEventB);

            var now = DateTime.UtcNow;
            this._timeServiceMock.SetupGet(tsm => tsm.UtcNow).Returns(now);

            var sut = this.CreateSut();

            await sut.Metadata.AddAsync(metadata);

            // Act
            await sut.SaveChangesAsync();

            // Arrange
            this._domainEventServiceMock.Verify(desm => desm.Publish(fakeDomainEventA), Times.Once);
            this._domainEventServiceMock.Verify(desm => desm.Publish(fakeDomainEventB), Times.Once);
        }

        private ApplicationDbContext CreateSut()
        {
            var databaseName = Guid.NewGuid().ToString();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase(databaseName);

            var applicationDbContext = new ApplicationDbContext(dbContextOptionsBuilder.Options, this._domainEventServiceMock.Object, this._timeServiceMock.Object);

            return applicationDbContext;
        }
    }
}