using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Entities;
using AddonCraft.Domain.Enums;
using AddonCraft.Infrastructure.Persistence.Names;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AddonCraft.Infrastructure.Persistence.Configurations
{
    /// <inheritdoc/>
    /// <summary>
    /// Provides configuration for the persistence of <see cref="Addon"/>.
    /// </summary>
    // ExcludeFromCodeCoverage: There is no value in testing this and it is extremely hard to test.
    [ExcludeFromCodeCoverage]
    public class AddonConfiguration : IEntityTypeConfiguration<Addon>
    {
        public void Configure(EntityTypeBuilder<Addon> builder)
        {
            builder
                .Ignore(a => a.DomainEvents);
            
            builder
                .Property(a => a.Name)
                .IsRequired();
            builder
                .Property(a => a.Version)
                .IsRequired();
            builder
                .Property(a => a.GameFlavor)
                .HasConversion(t => (GameFlavor.GameFlavorEnum) t,
                    f => GameFlavor.FromEnum(f))
                .IsRequired();
            builder
                .Property(a => a.ReleaseType)
                .HasConversion(
                    t => (ReleaseType.ReleaseTypeEnum) t,
                    f => ReleaseType.FromEnum(f))
                .IsRequired();

            builder
                .HasIndex(ColumnName.Id, ColumnName.GameFlavor, ColumnName.ReleaseType)
                .IsUnique();
            builder
                .HasIndex(ColumnName.Name, ColumnName.GameFlavor, ColumnName.ReleaseType)
                .IsUnique();

            builder
                .HasOne(a => a.Metadata)
                .WithMany();

            builder
                .OwnsMany(a => a.Modules, m =>
                {
                    m.WithOwner().HasForeignKey(ColumnName.AddonId);
                    m.Property<Guid>(ColumnName.Id).HasValueGenerator<GuidValueGenerator>();
                    m.HasKey(ColumnName.Id);
                    m.ToTable(TableName.Modules);
                });
        }
    }
}