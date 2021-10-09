using System.Net;
using System.Threading.Tasks;
using CommonComponents.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommonComponents.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentController
    {
        private readonly IMediator _mediator;

        public ComponentController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{componentId}", Name = "GetComponentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetComponentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetComponentById.Response>> GetById([FromRoute]GetComponentById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Component == null)
            {
                return new NotFoundObjectResult(request.ComponentId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetComponentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetComponents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetComponents.Response>> Get()
            => await _mediator.Send(new GetComponents.Request());
        
        [HttpPost(Name = "CreateComponentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateComponent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateComponent.Response>> Create([FromBody]CreateComponent.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetComponentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetComponentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetComponentsPage.Response>> Page([FromRoute]GetComponentsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateComponentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateComponent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateComponent.Response>> Update([FromBody]UpdateComponent.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{componentId}", Name = "RemoveComponentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveComponent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveComponent.Response>> Remove([FromRoute]RemoveComponent.Request request)
            => await _mediator.Send(request);
        
    }
}
