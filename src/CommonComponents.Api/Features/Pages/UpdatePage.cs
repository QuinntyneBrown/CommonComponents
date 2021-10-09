using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class UpdatePage
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
                var page = await _context.Pages.SingleAsync(x => x.PageId == request.Page.PageId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Page = page.ToDto()
                };
            }
            
        }
    }
}
