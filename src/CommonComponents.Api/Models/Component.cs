using CommonComponents.Api.Core;
using CommonComponents.Api.DomainEvents;
using System;

namespace CommonComponents.Api.Models
{
    public class Component : AggregateRoot
    {
        public Guid ComponentId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Component()
        {

        }

        public Component(CreateComponent @event)
        {
            Apply(@event);
        }


        protected override void When(dynamic @event) => When(@event);

        private void When(CreateComponent @event)
        {
            ComponentId = @event.ComponentId;
            Name = @event.Name;
            Description = @event.Description;
        }

        protected override void EnsureValidState()
        {

        }
    }
}
