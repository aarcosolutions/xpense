using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xpense.Contract.Repository;
using xpense.DataModel;

namespace xpense.Repository
{
    public class OrganisationRepository : BaseRepository, IOrganisationRepository
    {
        public OrganisationRepository(XpenseDbContext context):base(context)
        {
        }

        public void AddOrganisation(Organisation organisation)
        {
            if(organisation != null)
            {
                organisation.Key = Guid.NewGuid();
                _context.Organisations.Add(organisation);
            }
        }

        public void ArchiveOrganisation(Organisation organisation)
        {
            if(organisation != null)
            {
                organisation.IsArchived = true;
            }
        }

        public async Task<Organisation> GetOrganisation(Guid key)
        {
            return await _context.Organisations.FirstOrDefaultAsync(x => x.Key == key);
        }

        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            return await _context.Organisations.ToListAsync();
        }

        public async Task<bool> OrganisationExists(Guid key)
        {
            return await _context.Organisations.AnyAsync(x => x.Key == key);
        }

        public void UpdateOrganisation(Organisation organisation)
        {
            throw new NotImplementedException();
        }
    }
}
