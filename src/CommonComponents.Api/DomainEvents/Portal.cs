using CommonComponents.Api.Core;
using System;

namespace CommonComponents.Api.DomainEvents
{
    public class CreatePortal : BaseDomainEvent
    {
        public Guid PortalId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreatePortal(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class UpdatePortalDescription : BaseDomainEvent
    {
        public string Description { get; private set; }
        public UpdatePortalDescription(string description)
        {
            Description = description;
        }
    }

    public class QueryOrCreatePortal: BaseDomainEvent
    {
        public string Name { get; private set; }

        public QueryOrCreatePortal(string name)
        {
            Name = name;
        }
    }


    public class QueriedOrCreatedPortal : BaseDomainEvent
    {
        public Guid PortalId { get; private set; }

        public QueriedOrCreatedPortal(Guid portalId)
        {
            PortalId = portalId;
        }
    }

    public class RemovePortal : BaseDomainEvent
    {

    }
}
