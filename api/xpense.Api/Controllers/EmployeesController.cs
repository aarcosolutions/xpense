using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xpense.Contract.Repository;

namespace xpense.Api.Controllers
{
    [Route("organisations/{organisationKey}/employees")]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _employeeRepository { get; }

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/values
        [HttpGet("{employeeKey}")]
        public IEnumerable<string> GetEmployees(Guid organisationKey, Guid employeeKey)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
