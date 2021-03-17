using System;
using System.Threading;
using System.Threading.Tasks;
using AddonCraft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddonCraft.Application.Common.Persistence
{
    /// <summary>
    /// Defines the contract for the application context.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Represents the addons table.
        /// </summary>
        DbSet<Addon> Addons { get; }

        /// <summary>
        /// Represents the metadata table.
        /// </summary>
        DbSet<Metadata> Metadata { get; }

        /// <summary>
        /// Saves all changes made in this context to the database. This method will
        /// automatically call <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges"/>
        /// to discover any changes to entity instances before saving to the underlying
        /// database. This can be disabled via <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled"/>.
        /// Multiple active operations on the same context instance are not supported.
        /// Use 'await' to ensure that any asynchronous operations have completed
        /// before calling another method on this context.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        /// <exception cref="DbUpdateException">An error is encountered while saving to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">A concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory.</exception>
        Task<Int32> SaveChangesAsync(CancellationToken cancellationToken);
    }
}