using CommonComponents.Api.Core;
using CommonComponents.Api.DomainEvents;
using System;

namespace CommonComponents.Api.Models
{
    public class PortalComponent: AggregateRoot
    {
        public Guid PortalComponentId { get; set; }
        public Guid PortalId { get; set; }
        public Guid ComponentId { get; set; }
        public string Description { get; set; }

        public PortalComponent(CreatePortalComponent @event)
        {
            Apply(@event);
        }

        private PortalComponent()
        {

        }
        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreatePortalComponent @event)
        {
            PortalComponentId = @event.PortalComponentId;
            ComponentId = @event.ComponentId;
            PortalId = @event.PortalId;
        }
    }
}
