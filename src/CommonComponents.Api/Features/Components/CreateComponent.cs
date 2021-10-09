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
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var component = new Component();
                
                _context.Components.Add(component);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Component = component.ToDto()
                };
            }
            
        }
    }
}
