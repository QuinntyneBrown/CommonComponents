using System;

namespace CommonComponents.Api.Models
{
    public class Component
    {
        public Guid ComponentId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
