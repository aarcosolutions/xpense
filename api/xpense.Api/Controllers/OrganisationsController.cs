using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xpense.Contract.Repository;
using xpense.DataModel;
using AutoMapper;
using xpense.DataModel.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace xpense.Api.Controllers
{
    [Route("organisations")]
    public class OrganisationsController : Controller
    {
        private IOrganisationRepository _organisationRepository { get; }
        private IMapper _mapper { get; }

        public OrganisationsController(IOrganisationRepository organisationRepository, IMapper mapper)
        {
            _organisationRepository = organisationRepository;
            _mapper = mapper;
        }

        [HttpGet(Name ="GetOrganisations")]
        public async Task<IActionResult> GetOrganisations()
        {
            var organisations =  await _organisationRepository.GetOrganisations();
            var map = _mapper.Map<IEnumerable<OrganisationDto>>(organisations);
            return Ok(map);
        }

        [HttpGet("{key}",Name = "GetOrganisation")]
        public async Task<IActionResult> GetOrganisation(Guid key)
        {
            var organisation =  await _organisationRepository.GetOrganisation(key);
            if (organisation == null)
            {
                return NotFound();
            }

            var map = _mapper.Map<OrganisationDto>(organisation);
            return Ok(map);

        }
    }
}
