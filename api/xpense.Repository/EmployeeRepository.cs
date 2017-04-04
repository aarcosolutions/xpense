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
        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void ArchiveEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EmployeeExists(Guid organisationKey, Guid employeeKey)
        {
            return await _context.Employees.AnyAsync(x => x.Organisation.Key == organisationKey && x.Key == employeeKey);
        }

        public async Task<Employee> GetEmployee(Guid organisationKey, Guid employeeKey)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Organisation.Key == organisationKey && x.Key == employeeKey);
        }

        public async Task<IEnumerable<Employee>> GetEmployees(Guid organisationKey)
        {
            return await _context.Employees.Where(x => x.Organisation.Key == organisationKey).ToListAsync();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
