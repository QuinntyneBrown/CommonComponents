using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CommonComponents.Api.Extensions;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using CommonComponents.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class GetComponentsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<ComponentDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from component in _context.Components
                    select component;
                
                var length = await _context.Components.CountAsync();
                
                var components = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = components
                };
            }
            
        }
    }
}
