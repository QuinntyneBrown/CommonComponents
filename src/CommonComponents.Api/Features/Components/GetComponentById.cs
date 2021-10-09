using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class GetComponentById
    {
        public class Request: IRequest<Response>
        {
            public Guid ComponentId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ComponentDto Component { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Component = (await _context.Components.SingleOrDefaultAsync(x => x.ComponentId == request.ComponentId)).ToDto()
                };
            }
            
        }
    }
}
