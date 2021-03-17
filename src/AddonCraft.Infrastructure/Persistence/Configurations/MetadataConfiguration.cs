using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddonCraft.Infrastructure.Persistence.Configurations
{
    /// <inheritdoc/>
    /// <summary>
    /// Provides configuration for the persistence of <see cref="Metadata"/>.
    /// </summary>
    // ExcludeFromCodeCoverage: There is no value in testing this and it is extremely hard to test.
    [ExcludeFromCodeCoverage]
    public class MetadataConfiguration : IEntityTypeConfiguration<Metadata>
    {
        public void Configure(EntityTypeBuilder<Metadata> builder)
        {
            builder
                .Ignore(p => p.DomainEvents);

            builder
                .Property(m => m.PackageName)
                .IsRequired();

            builder
                .HasIndex(m => m.PackageName)
                .IsUnique();
        }
    }
}