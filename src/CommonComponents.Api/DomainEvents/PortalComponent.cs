using CommonComponents.Api.Core;
using System;

namespace CommonComponents.Api.DomainEvents
{
    public class CreatePortalComponent : BaseDomainEvent
    {
        public Guid PortalComponentId { get; private set; } = Guid.NewGuid();
        public Guid ComponentId { get; private set; }
        public Guid PortalId { get; private set; }
        public string Description { get; private set; }

        public CreatePortalComponent(Guid componetId, Guid portalId, string description)
        {
            ComponentId = componetId;
            PortalId = portalId;
            Description = description;
        }
    }

    public class UpdatePortalComponentDescription : BaseDomainEvent
    {
        public string Description { get; private set; }
        public UpdatePortalComponentDescription(string description)
        {
            Description = description;
        }
    }

    public class RemovePortalComponent : BaseDomainEvent
    {

    }
}
