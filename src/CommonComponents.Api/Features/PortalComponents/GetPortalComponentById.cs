using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class GetPortalComponentById
    {
        public class Request: IRequest<Response>
        {
            public Guid PortalComponentId { get; set; }
        }

        public class Response: ResponseBase
        {
            public PortalComponentDto PortalComponent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    PortalComponent = (await _context.PortalComponents.SingleOrDefaultAsync(x => x.PortalComponentId == request.PortalComponentId)).ToDto()
                };
            }
            
        }
    }
}
