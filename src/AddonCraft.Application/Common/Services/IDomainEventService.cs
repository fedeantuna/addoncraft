using System.Threading.Tasks;
using AddonCraft.Domain.Bases;

namespace AddonCraft.Application.Common.Services
{
    /// <summary>
    /// Defines the contract for the Domain Event Service.
    /// </summary>
    public interface IDomainEventService
    {
        /// <summary>
        /// Publishes a Domain Event.
        /// </summary>
        /// <param name="domainEvent">The domain event.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task Publish(DomainEvent domainEvent);

        /// <summary>
        /// Raises an event adding it to the entity associated to it.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <param name="entity">The entity associated with the event.</param>
        void RaiseEvent<TEvent>(Entity entity)
            where TEvent : DomainEvent;
    }
}