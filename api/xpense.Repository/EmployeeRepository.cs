using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpense.Contract.Repository;
using xpense.DataModel;

namespace xpense.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    { 
        public EmployeeRepository(XpenseDbContext context):base(context)
        {
        }
        public async Task AddEmployee(Employee employee, Guid organisationKey)
        {
            if(employee != null)
            {
                var org = await _context.Organisations.FirstOrDefaultAsync(o => o.Key == organisationKey);
                employee.Organisation = org ?? throw new Exception($"Organisation {organisationKey} does not exists");
                employee.Key = Guid.NewGuid();
                _context.Employees.Add(employee);
            }
        }

        public Task ArchiveEmployee(Employee employee, Guid organisationKey)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EmployeeExists(Guid organisationKey, Guid employeeKey)
        {
            return await _context.Employees.AnyAsync(x => x.Organisation.Key == organisationKey && x.Key == employeeKey);
        }

        public async Task<Employee> GetEmployee(Guid organisationKey, Guid employeeKey)
        {
            return await _context.Employees
                            .Include(x=>x.Organisation)
                            .FirstOrDefaultAsync(x => x.Organisation.Key == organisationKey && x.Key == employeeKey);
        }

        public async Task<IEnumerable<Employee>> GetEmployees(Guid organisationKey)
        {
            return await _context.Employees
                            .Include(x=>x.Organisation)
                            .Where(x => x.Organisation.Key == organisationKey)
                            .ToListAsync();
        }

        public Task UpdateEmployee(Employee employee, Guid organisationKey)
        {
            throw new NotImplementedException();
        }
    }
}
