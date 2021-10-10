using System;
using CommonComponents.Api.Models;

namespace CommonComponents.Api.Features
{
    public static class PortalExtensions
    {
        public static PortalDto ToDto(this Portal portal)
        {
            return new ()
            {
                PortalId = portal.PortalId,
                Name = portal.Name,
                Description = portal.Description
            };
        }
        
    }
}
