using CommonComponents.Api.DomainEvents;
using CommonComponents.Api.Interfaces;
using CommonComponents.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace CommonComponents.Api.Features
{
    public class PortalComponentEventHandler : INotificationHandler<DomainEvents.CreatePortalComponent>
    {
        private readonly ICommonComponentsDbContext _context;
        private readonly IOrchestrationHandler _orchestrationHandler;

        public PortalComponentEventHandler(
            ICommonComponentsDbContext context,
            IOrchestrationHandler orchestrationHandler
            )
        {
            _context = context;
            _orchestrationHandler = orchestrationHandler;
        }

        public async Task Handle(DomainEvents.CreatePortalComponent @event, CancellationToken cancellationToken)
        {
            var portalComponent = new PortalComponent(new DomainEvents.CreatePortalComponent(@event.ComponentId,@event.PortalId, default));

            _context.PortalComponents.Add(portalComponent);

            await _context.SaveChangesAsync(cancellationToken);

            await _orchestrationHandler.Publish(new CreatedPortalComponent());
        }
    }
}
