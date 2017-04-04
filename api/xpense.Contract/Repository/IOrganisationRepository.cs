using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xpense.DataModel;

namespace xpense.Contract.Repository
{
    public interface IOrganisationRepository: IBaseRepository
    {
        Task<Organisation> GetOrganisation(Guid key);
        Task<IEnumerable<Organisation>> GetOrganisations();
        void AddOrganisation(Organisation organisation);
        void ArchiveOrganisation(Organisation organisation);
        void UpdateOrganisation(Organisation organisation);
        Task<bool> OrganisationExists(Guid key);
    }
}
