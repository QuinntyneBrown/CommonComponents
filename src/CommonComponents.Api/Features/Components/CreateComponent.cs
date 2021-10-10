using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Models;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;

namespace CommonComponents.Api.Features
{
    public class CreateComponent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Component).NotNull();
                RuleFor(request => request.Component).SetValidator(new ComponentValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ComponentDto Component { get; set; }
        }

        public class Response: ResponseBase
        {
            public ComponentDto Component { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
            private readonly IOrchestrationHandler _orchestrationHandler;
        
            public Handler(ICommonComponentsDbContext context, IOrchestrationHandler orchestrationHandler)
            {
                _context = context;
                _orchestrationHandler = orchestrationHandler;
            } 
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var startWith = new DomainEvents.QueryOrCreatePortal(request.Component.Portal.Name);

                Component component = default;

                return await _orchestrationHandler.Handle<Response>(startWith, (ctx) => async message =>
                {
                    switch(message)
                    {
                        case DomainEvents.QueriedOrCreatedPortal @event:
                            component = new Component(new(request.Component.Name, request.Component.Description));
                            
                            _context.Components.Add(component);

                            await _context.SaveChangesAsync(cancellationToken);

                            await _orchestrationHandler.Publish(new DomainEvents.CreatePortalComponent(
                                component.ComponentId,
                                @event.PortalId,
                                default));
                            break;

                        case DomainEvents.CreatedPortalComponent @event:
                            ctx.SetResult(new()
                            {
                                Component = component.ToDto()
                            });
                            break;
                    }
                });
            }
            
        }
    }
}
