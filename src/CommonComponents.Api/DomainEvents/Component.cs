using CommonComponents.Api.Core;
using System;

namespace CommonComponents.Api.DomainEvents
{
    public class CreateComponent : BaseDomainEvent
    {
        public Guid ComponentId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreateComponent(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class UpdateComponentDescription : BaseDomainEvent
    {
        public string Description { get; private set; }
        public UpdateComponentDescription(string description)
        {
            Description = description;
        }
    }

    public class RemoveComponent : BaseDomainEvent
    {

    }
}
