using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonComponents.Api.Features
{
    public class GetPageById
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
                return new () {
                    Page = (await _context.Pages.SingleOrDefaultAsync(x => x.PageId == request.PageId)).ToDto()
                };
            }
            
        }
    }
}
