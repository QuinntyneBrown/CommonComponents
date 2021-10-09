using System;
using CommonComponents.Api.Models;

namespace CommonComponents.Api.Features
{
    public static class StoredEventExtensions
    {
        public static StoredEventDto ToDto(this StoredEvent storedEvent)
        {
            return new ()
            {
                StoredEventId = storedEvent.StoredEventId
            };
        }
        
    }
}
