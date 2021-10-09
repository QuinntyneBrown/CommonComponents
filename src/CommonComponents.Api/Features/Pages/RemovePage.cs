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
    public class RemovePage
    {
        public class Request: IRequest<Response>
        {
            public Guid PageId { get; set; }
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
                var page = await _context.Pages.SingleAsync(x => x.PageId == request.PageId);
                
                _context.Pages.Remove(page);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Page = page.ToDto()
                };
            }
            
        }
    }
}
