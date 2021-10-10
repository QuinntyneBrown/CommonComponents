using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Models;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;

namespace CommonComponents.Api.Features
{
    public class CreatePortalComponent
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
                var portalComponent = new PortalComponent(
                    new DomainEvents.CreatePortalComponent(default,default,default)
                    );
                
                _context.PortalComponents.Add(portalComponent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    PortalComponent = portalComponent.ToDto()
                };
            }
            
        }
    }
}
