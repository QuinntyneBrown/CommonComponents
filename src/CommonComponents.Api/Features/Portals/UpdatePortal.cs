using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class UpdatePortal
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Portal).NotNull();
                RuleFor(request => request.Portal).SetValidator(new PortalValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public PortalDto Portal { get; set; }
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
                var portal = await _context.Portals.SingleAsync(x => x.PortalId == request.Portal.PortalId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Portal = portal.ToDto()
                };
            }
            
        }
    }
}
