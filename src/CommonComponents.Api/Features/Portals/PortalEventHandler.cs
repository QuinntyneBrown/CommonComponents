using CommonComponents.Api.DomainEvents;
using CommonComponents.Api.Interfaces;
using CommonComponents.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace CommonComponents.Api.Features
{
    public class PortalEventHandler : INotificationHandler<QueryOrCreatePortal>
    {
        private readonly ICommonComponentsDbContext _context;
        private readonly IOrchestrationHandler _orchestrationHandler;

        public PortalEventHandler(
            ICommonComponentsDbContext context,
            IOrchestrationHandler orchestrationHandler
            )
        {
            _context = context;
            _orchestrationHandler = orchestrationHandler;
        }

        public async Task Handle(DomainEvents.QueryOrCreatePortal @event, CancellationToken cancellationToken)
        {
            var portal = await _context.Portals.SingleOrDefaultAsync(x => x.Name == @event.Name);

            if (portal == null)
            {
                portal = new Portal(new (@event.Name, default));

                _context.Portals.Add(portal);

                await _context.SaveChangesAsync(cancellationToken);
            }

            await _orchestrationHandler.Publish(new QueriedOrCreatedPortal(portal.PortalId));
        }
    }
}
