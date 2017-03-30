using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xpense.DataModel;

namespace xpense.Contract.Repository
{
    public interface IOrganisationRepository
    {
        Task<Organisation> GetOrganisation(Guid key);
        Task<IEnumerable<Organisation>> GetOrganisations();
        Task AddOrganisation(Organisation organisation);
        Task ArchiveOrganisation(Organisation organisation);
        Task UpdateOrganisation(Organisation organisation);
        Task<bool> OrganisationExists(Guid key);
    }
}
