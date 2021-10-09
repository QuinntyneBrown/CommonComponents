using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class GetPortalComponents
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<PortalComponentDto> PortalComponents { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    PortalComponents = await _context.PortalComponents.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
