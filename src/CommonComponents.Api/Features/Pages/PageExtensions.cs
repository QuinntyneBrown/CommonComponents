using System;
using CommonComponents.Api.Models;

namespace CommonComponents.Api.Features
{
    public static class PageExtensions
    {
        public static PageDto ToDto(this Page page)
        {
            return new ()
            {
                PageId = page.PageId
            };
        }
        
    }
}
