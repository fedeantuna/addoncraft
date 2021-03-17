using System;
using System.Threading.Tasks;
using AddonCraft.Application.Common.Models;
using AddonCraft.Application.Common.Services;
using AddonCraft.Domain.Bases;
using AddonCraft.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AddonCraft.Infrastructure.Services
{
    /// <inheritdoc/>
    /// <summary>
    /// Service to manage Domain Events.
    /// </summary>
    public class DomainEventService : IDomainEventService
    {
        private readonly ITimeService _timeService;
        private readonly IMediator _mediator;
        private readonly ILogger<DomainEventService> _logger;

        /// <summary>
        /// Initializes the Domain Event Service.
        /// </summary>
        /// <param name="timeService">The Time Service dependency.</param>
        /// <param name="logger">The Logger dependency.</param>
        /// <param name="mediator">The Mediator dependency.</param>
        public DomainEventService(ITimeService timeService,
            IMediator mediator,
            ILogger<DomainEventService> logger)
        {
            this._timeService = timeService;
            this._mediator = mediator;
            this._logger = logger;
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            const String message = "Publishing domain event. Event - {Event}";
            _logger.LogInformation(message, domainEvent.GetType().Name);

            await this._mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        public void RaiseEvent<TEvent>(Entity entity)
            where TEvent : DomainEvent
        {
            var @event = (DomainEvent)Activator.CreateInstance(typeof(TEvent), this._timeService);

            entity.AddDomainEvent(@event);
        }

        private static INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent) =>
            (INotification)Activator.CreateInstance(typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
    }
}