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
    public class RemovePortalComponent
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
                var portalComponent = await _context.PortalComponents.SingleAsync(x => x.PortalComponentId == request.PortalComponentId);
                
                _context.PortalComponents.Remove(portalComponent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    PortalComponent = portalComponent.ToDto()
                };
            }
            
        }
    }
}
