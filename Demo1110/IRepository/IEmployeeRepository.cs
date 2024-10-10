using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1110.Model;

namespace Demo1110.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}