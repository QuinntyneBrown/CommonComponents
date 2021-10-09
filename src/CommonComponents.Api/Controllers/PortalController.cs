using System.Net;
using System.Threading.Tasks;
using CommonComponents.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommonComponents.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortalController
    {
        private readonly IMediator _mediator;

        public PortalController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{portalId}", Name = "GetPortalByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPortalById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPortalById.Response>> GetById([FromRoute]GetPortalById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Portal == null)
            {
                return new NotFoundObjectResult(request.PortalId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetPortalsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPortals.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPortals.Response>> Get()
            => await _mediator.Send(new GetPortals.Request());
        
        [HttpPost(Name = "CreatePortalRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePortal.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePortal.Response>> Create([FromBody]CreatePortal.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetPortalsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPortalsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPortalsPage.Response>> Page([FromRoute]GetPortalsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdatePortalRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePortal.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePortal.Response>> Update([FromBody]UpdatePortal.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{portalId}", Name = "RemovePortalRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePortal.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePortal.Response>> Remove([FromRoute]RemovePortal.Request request)
            => await _mediator.Send(request);
        
    }
}
