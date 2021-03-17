using AddonCraft.Domain.Bases;
using MediatR;

namespace AddonCraft.Application.Common.Models
{
    /// <summary>
    /// Represents a Domain Event Notification.
    /// </summary>
    /// <typeparam name="TDomainEvent">The type of the Domain Event.</typeparam>
    public class DomainEventNotification<TDomainEvent> : INotification
        where TDomainEvent : DomainEvent
    {
        /// <summary>
        /// Initializes the Domain Event Notification.
        /// </summary>
        /// <param name="domainEvent">The Domain Event.</param>
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            this.DomainEvent = domainEvent;
        }

        /// <summary>
        /// Domain Event associated with the Notification.
        /// </summary>
        public TDomainEvent DomainEvent { get; }
    }
}