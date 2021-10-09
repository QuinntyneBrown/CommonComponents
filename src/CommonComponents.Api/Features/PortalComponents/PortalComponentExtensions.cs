using System;
using CommonComponents.Api.Models;

namespace CommonComponents.Api.Features
{
    public static class PortalComponentExtensions
    {
        public static PortalComponentDto ToDto(this PortalComponent portalComponent)
        {
            return new ()
            {
                PortalComponentId = portalComponent.PortalComponentId
            };
        }
        
    }
}
