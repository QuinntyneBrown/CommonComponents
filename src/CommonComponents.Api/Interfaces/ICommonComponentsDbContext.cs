using CommonComponents.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace CommonComponents.Api.Interfaces
{
    public interface ICommonComponentsDbContext
    {
        DbSet<Component> Components { get; }
        DbSet<Portal> Portals { get; }
        DbSet<PortalComponent> PortalComponents { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<Page> Pages { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
