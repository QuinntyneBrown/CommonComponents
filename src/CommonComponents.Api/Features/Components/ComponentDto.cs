using System;

namespace CommonComponents.Api.Features
{
    public class ComponentDto
    {
        public Guid? ComponentId { get; set; }
        public PortalDto Portal { get; set; }
        public Guid PortalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
