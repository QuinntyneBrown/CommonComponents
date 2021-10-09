using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class UpdatePortalComponent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.PortalComponent).NotNull();
                RuleFor(request => request.PortalComponent).SetValidator(new PortalComponentValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public PortalComponentDto PortalComponent { get; set; }
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
                var portalComponent = await _context.PortalComponents.SingleAsync(x => x.PortalComponentId == request.PortalComponent.PortalComponentId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    PortalComponent = portalComponent.ToDto()
                };
            }
            
        }
    }
}
