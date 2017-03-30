using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xpense.Contract.Repository;
using xpense.DataModel;

namespace xpense.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private XpenseDbContext _context { get; }

        public OrganisationRepository(XpenseDbContext context)
        {
            _context = context;
        }

        public Task AddOrganisation(Organisation organisation)
        {
            throw new NotImplementedException();
        }

        public Task ArchiveOrganisation(Organisation organisation)
        {
            throw new NotImplementedException();
        }

        public async Task<Organisation> GetOrganisation(Guid key)
        {
            return await _context.Organisations.FirstOrDefaultAsync(x => x.Key == key);
        }

        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            return await _context.Organisations.ToListAsync();
        }

        public Task<bool> OrganisationExists(Guid key)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrganisation(Organisation organisation)
        {
            throw new NotImplementedException();
        }
    }
}
