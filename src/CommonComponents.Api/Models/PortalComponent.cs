using CommonComponents.Api.Core;
using System;

namespace CommonComponents.Api.Models
{
    public class PortalComponent: AggregateRoot
    {
        public Guid PortalComponentId { get; set; }
        public Guid PortalId { get; set; }
        public Guid ComponentId { get; set; }
        public string Description { get; set; }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);
    }
}
