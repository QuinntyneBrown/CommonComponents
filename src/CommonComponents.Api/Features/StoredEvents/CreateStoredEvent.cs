using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Models;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;

namespace CommonComponents.Api.Features
{
    public class CreateStoredEvent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.StoredEvent).NotNull();
                RuleFor(request => request.StoredEvent).SetValidator(new StoredEventValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Response: ResponseBase
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var storedEvent = new StoredEvent();
                
                _context.StoredEvents.Add(storedEvent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    StoredEvent = storedEvent.ToDto()
                };
            }
            
        }
    }
}
