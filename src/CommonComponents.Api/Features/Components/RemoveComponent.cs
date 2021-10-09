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
    public class RemoveComponent
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
                var component = await _context.Components.SingleAsync(x => x.ComponentId == request.ComponentId);
                
                _context.Components.Remove(component);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Component = component.ToDto()
                };
            }
            
        }
    }
}
