using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using xpense.Contract.Model;
using System.Threading;

namespace xpense.Repository
{
    public abstract class BaseDbContext<TContext>:DbContext where TContext: DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options):base(options)
        {
            Database.Migrate();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyAuditRule();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyAuditRule();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            ApplyAuditRule();
            return base.SaveChanges();
        }

        private void ApplyAuditRule()
        {
            var entities = ChangeTracker.Entries<IAuditable>()
                                   .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                                   .Select(e => new { e.Entity, e.State });
            foreach (var e in entities)
            {
                if (e.State == EntityState.Added)
                    e.Entity.DateCreated = DateTime.Now;

                e.Entity.DateModified = DateTime.Now;
            }
        }


    }
}
