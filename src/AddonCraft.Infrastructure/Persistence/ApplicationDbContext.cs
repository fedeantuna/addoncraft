using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AddonCraft.Application.Common.Persistence;
using AddonCraft.Application.Common.Services;
using AddonCraft.Domain.Bases;
using AddonCraft.Domain.Entities;
using AddonCraft.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AddonCraft.Infrastructure.Persistence
{
    /// <inheritdoc cref="DbContext"/>
    /// <summary>
    /// Represents a session with the database and can be used to query and save instances of the entities.
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDomainEventService _domainEventService;
        private readonly ITimeService _timeService;

        public ApplicationDbContext(DbContextOptions dbContextOptions,
            IDomainEventService domainEventService,
            ITimeService timeService)
            : base(dbContextOptions)
        {
            this._domainEventService = domainEventService;
            this._timeService = timeService;
        }

        public DbSet<Addon> Addons { get; set; }

        public DbSet<Metadata> Metadata { get; set; }

        public override async Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = this.ChangeTracker.Entries<Entity>().ToList();

            var modifiedEntries = entries.Where(e => e.State == EntityState.Modified);
            var addedEntries = entries.Where(e => e.State == EntityState.Added);

            foreach (var modifiedEntry in modifiedEntries)
            {
                modifiedEntry.Entity.SetLastModifiedDate(this._timeService.UtcNow);
            }

            foreach (var addedEntry in addedEntries)
            {
                addedEntry.Entity.SetCreatedAtDate(this._timeService.UtcNow);
            }

            await this.DispatchEvents();

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        private async Task DispatchEvents()
        {
            var domainEvents = this.ChangeTracker.Entries<Entity>()
                .Select(ee => ee.Entity.DomainEvents)
                .SelectMany(de => de)
                .ToArray();

            foreach (var domainEvent in domainEvents)
            {
                await this._domainEventService.Publish(domainEvent);
            }
        }
    }
}