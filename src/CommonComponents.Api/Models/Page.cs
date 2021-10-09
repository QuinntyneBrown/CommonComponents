using CommonComponents.Api.Core;
using CommonComponents.Api.DomainEvents;
using System;

namespace CommonComponents.Api.Models
{
    public class Page: AggregateRoot
    {
        public Guid PageId { get; private set; }
        public Guid PortalId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Page(CreatePage @event)
        {

        }

        protected override void When(dynamic @event) => When(@event);

        protected override void EnsureValidState()
        {

        }
    }
}
