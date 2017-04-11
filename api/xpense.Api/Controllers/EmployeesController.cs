using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xpense.Contract.Repository;
using AutoMapper;
using xpense.DataModel.Dto;
using xpense.DataModel;

namespace xpense.Api.Controllers
{
    [Route("organisations/{organisationKey}/employees")]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _employeeRepository { get; }
        private IMapper _mapper { get; }

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet("{employeeKey}", Name ="GetEmployee")]
        public async Task<IActionResult> GetEmployee(Guid organisationKey, Guid employeeKey)
        {
            var employee = await _employeeRepository.GetEmployee(organisationKey, employeeKey);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<IActionResult> GetEmployees(Guid organisationKey)
        {
            var employee = await _employeeRepository.GetEmployees(organisationKey);
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employee));
        }

        [HttpPost(Name="CreateEmployee")]
        public async Task<IActionResult>CreateEmployee([FromBody] EmployeeDto employee, Guid organisationKey)
        {
            if (employee == null)
                return BadRequest();

            var emp = _mapper.Map<Employee>(employee);  
            await _employeeRepository.AddEmployee(emp, organisationKey);
            if(!await _employeeRepository.Save())
            {
                throw new Exception("Employee creation failed");
            }

            var empDto = _mapper.Map<EmployeeDto>(emp);

            return CreatedAtRoute("GetEmployee", new {organisationKey=emp.Organisation.Key, employeeKey = emp.Key}, empDto);
        }
    }
}
