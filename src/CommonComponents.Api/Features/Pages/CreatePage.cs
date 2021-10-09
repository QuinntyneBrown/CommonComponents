using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Models;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;

namespace CommonComponents.Api.Features
{
    public class CreatePage
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Page).NotNull();
                RuleFor(request => request.Page).SetValidator(new PageValidator());
            }
        }

        public class Request: IRequest<Response>
        {
            public PageDto Page { get; set; }
        }

        public class Response: ResponseBase
        {
            public PageDto Page { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICommonComponentsDbContext _context;
        
            public Handler(ICommonComponentsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var page = new Page(new (request.Page.Name, request.Page.Description));
                
                _context.Pages.Add(page);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Page = page.ToDto()
                };
            }
        }
    }
}
