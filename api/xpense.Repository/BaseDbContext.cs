using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using xpense.Contract.Model;

namespace xpense.Repository
{
    public abstract class BaseDbContext<TContext>:DbContext where TContext: DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options):base(options)
        {

        }

        public Task<int> SaveChangesAsync(bool applyAuditRules)
        {
            if (applyAuditRules)
                ApplyAuditRule();

            return base.SaveChangesAsync();
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
