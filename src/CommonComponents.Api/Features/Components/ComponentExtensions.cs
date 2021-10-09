using System;
using CommonComponents.Api.Models;

namespace CommonComponents.Api.Features
{
    public static class ComponentExtensions
    {
        public static ComponentDto ToDto(this Component component)
        {
            return new ()
            {
                ComponentId = component.ComponentId
            };
        }
        
    }
}
