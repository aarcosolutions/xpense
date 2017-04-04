using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xpense.DataModel;

namespace xpense.Contract.Repository
{
    public interface IEmployeeRepository:IBaseRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(Guid organisationKey);
        Task<Employee> GetEmployee(Guid organisationKey, Guid employeeKey);
        Task<bool> EmployeeExists(Guid organisationKey, Guid employeeKey);
        void ArchiveEmployee(Employee employee);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
