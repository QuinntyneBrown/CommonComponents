using CommonComponents.Api.Core;
using CommonComponents.Api.Interfaces;
using CommonComponents.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CommonComponents.Api.Data
{
    public class CommonComponentsDbContext: DbContext, ICommonComponentsDbContext
    {
        public DbSet<Component> Components { get; private set; }
        public DbSet<Portal> Portals { get; private set; }
        public DbSet<PortalComponent> PortalComponents { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<Page> Pages { get; private set; }
        public CommonComponentsDbContext(DbContextOptions options): base(options)
        {
            SavingChanges += DbContext_SavingChanges;
        }

        private void DbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Where(
                    e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();
            
            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    StoredEvents.Add(storedEvent);
                }
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommonComponentsDbContext).Assembly);
        }
        
        public override void Dispose()
        {
            SavingChanges -= DbContext_SavingChanges;
            
            base.Dispose();
        }
        
        public override ValueTask DisposeAsync()
        {
            SavingChanges -= DbContext_SavingChanges;
            
            return base.DisposeAsync();
        }
        
    }
}
