using System.Net;
using System.Threading.Tasks;
using CommonComponents.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommonComponents.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortalComponentController
    {
        private readonly IMediator _mediator;

        public PortalComponentController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{portalComponentId}", Name = "GetPortalComponentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPortalComponentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPortalComponentById.Response>> GetById([FromRoute]GetPortalComponentById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.PortalComponent == null)
            {
                return new NotFoundObjectResult(request.PortalComponentId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetPortalComponentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPortalComponents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPortalComponents.Response>> Get()
            => await _mediator.Send(new GetPortalComponents.Request());
        
        [HttpPost(Name = "CreatePortalComponentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePortalComponent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePortalComponent.Response>> Create([FromBody]CreatePortalComponent.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetPortalComponentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPortalComponentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPortalComponentsPage.Response>> Page([FromRoute]GetPortalComponentsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdatePortalComponentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePortalComponent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePortalComponent.Response>> Update([FromBody]UpdatePortalComponent.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{portalComponentId}", Name = "RemovePortalComponentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePortalComponent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePortalComponent.Response>> Remove([FromRoute]RemovePortalComponent.Request request)
            => await _mediator.Send(request);
        
    }
}
