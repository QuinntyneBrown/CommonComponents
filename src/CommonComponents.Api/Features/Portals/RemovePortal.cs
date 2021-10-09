using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using CommonComponents.Api.Models;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;

namespace CommonComponents.Api.Features
{
    public class RemovePortal
    {
        public class Request: IRequest<Response>
        {
            public Guid PortalId { get; set; }
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
                
                _context.Portals.Remove(portal);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Portal = portal.ToDto()
                };
            }
            
        }
    }
}
