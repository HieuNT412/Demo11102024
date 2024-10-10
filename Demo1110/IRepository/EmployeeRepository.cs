using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1110.Model;
using Demo1110.Repository;

namespace Demo1110.IRepository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext db) : base(db)
        {
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) { Delete(employee); }

        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) => FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges).SingleOrDefault();

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) => FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).OrderBy(e => e.Name).ToList();
    }
}