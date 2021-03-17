using System;
using System.Collections.Generic;

namespace AddonCraft.Domain.Bases
{
    /// <summary>
    /// Base for entities.
    /// </summary>
    public abstract class Entity
    {
        private readonly ICollection<DomainEvent> _domainEvents;

        /// <summary>
        /// Initializes the Entity with a random id.
        /// </summary>
        protected Entity()
        {
            this._domainEvents = new List<DomainEvent>();

            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Identifier for the entity.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The exact time at which the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// The exact time at which the entity was last modified.
        /// </summary>
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The domain events raised for this entity.
        /// </summary>
        public IEnumerable<DomainEvent> DomainEvents => this._domainEvents;

        /// <summary>
        /// Adds a domain event to this entity.
        /// </summary>
        /// <param name="domainEvent">The raised domain event.</param>
        public void AddDomainEvent(DomainEvent domainEvent) => this._domainEvents.Add(domainEvent);

        /// <summary>
        /// Sets the time at which the entity was created.
        /// </summary>
        /// <param name="dateTime">The time.</param>
        public void SetCreatedAtDate(DateTime dateTime) => this.CreatedAt = dateTime;

        /// <summary>
        /// Sets the time at which the entity was last modified.
        /// </summary>
        /// <param name="dateTime">The time.</param>
        public void SetLastModifiedDate(DateTime dateTime) => this.LastModified = dateTime;
    }
}