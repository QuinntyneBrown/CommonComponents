using CommonComponents.Api.Core;
using System;

namespace CommonComponents.Api.DomainEvents
{
    public class CreatePage : BaseDomainEvent
    {
        public Guid PageId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreatePage(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class UpdatePageDescription : BaseDomainEvent
    {
        public string Description { get; private set; }
        public UpdatePageDescription(string description)
        {
            Description = description;
        }
    }

    public class RemovePage : BaseDomainEvent
    {

    }
}
