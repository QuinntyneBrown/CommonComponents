using CommonComponents.Api.Core;
using CommonComponents.Api.DomainEvents;
using System;

namespace CommonComponents.Api.Models
{
    public class Portal: AggregateRoot
    {
        public Guid PortalId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Portal(CreatePortal @event)
        {
            Apply(@event);
        }

        private Portal()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreatePortal @event)
        {
            PortalId = @event.PortalId;
            Name = @event.Name;
            Description = @event.Description;
        }

        private void When(UpdatePortalDescription @event)
        {
            Description = @event.Description;
        }

        protected override void EnsureValidState()
        {
            
        }
    }
}
