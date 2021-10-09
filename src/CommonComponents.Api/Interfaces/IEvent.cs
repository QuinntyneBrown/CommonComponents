using MediatR;
using System;

namespace CommonComponents.Api.Interfaces
{
    public interface IEvent : INotification
    {
        DateTime Created { get; }
        Guid CorrelationId { get; }
        void WithCorrelationIdFrom(IEvent @event);
    }
}
