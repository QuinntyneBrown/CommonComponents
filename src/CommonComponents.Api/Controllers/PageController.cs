using System.Net;
using System.Threading.Tasks;
using CommonComponents.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommonComponents.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController
    {
        private readonly IMediator _mediator;

        public PageController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{pageId}", Name = "GetPageByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPageById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPageById.Response>> GetById([FromRoute]GetPageById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Page == null)
            {
                return new NotFoundObjectResult(request.PageId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetPagesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPages.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPages.Response>> Get()
            => await _mediator.Send(new GetPages.Request());
        
        [HttpPost(Name = "CreatePageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePage.Response>> Create([FromBody]CreatePage.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetPagesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPagesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPagesPage.Response>> Page([FromRoute]GetPagesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdatePageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePage.Response>> Update([FromBody]UpdatePage.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{pageId}", Name = "RemovePageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePage.Response>> Remove([FromRoute]RemovePage.Request request)
            => await _mediator.Send(request);
        
    }
}
