using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommonComponents.Api.Features
{
    public class UpdatePortalDescription
    {
        public class Request: IRequest<Response>
        {
            public Guid PortalId { get; set; }
            public string Description { get; set; }
        }

        public class Response: ResponseBase
        {
            public PortalDto Portal { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var portal = await _context.Portals.SingleAsync(x => x.PortalId == request.PortalId);

                portal.Apply(new DomainEvents.UpdatePortalDescription(request.Description));
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Portal = portal.ToDto()
                };
            }
        }
    }
}
