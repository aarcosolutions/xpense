using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xpense.Contract.Repository;
using xpense.DataModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace xpense.Api.Controllers
{
    [Route("organisations")]
    public class OrganisationsController : Controller
    {
        private IOrganisationRepository _organisationRepository { get; }
        public OrganisationsController(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
        }

        [HttpGet(Name ="GetOrganisations")]
        public async Task<IActionResult> GetOrganisations()
        {
            var organisations =  await _organisationRepository.GetOrganisations();
            return new JsonResult(organisations);
        }

        [HttpGet("{key}",Name = "GetOrganisation")]
        public async Task<IActionResult> GetOrganisation(Guid key)
        {
            var organisation =  await _organisationRepository.GetOrganisation(key);
            return new JsonResult(organisation);
        }
    }
}
