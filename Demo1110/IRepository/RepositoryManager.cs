using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1110.Model;
using Demo1110.Repository;

namespace Demo1110.IRepository
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _db;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;

        public RepositoryManager(AppDbContext db){
            _db = db;
        }
        public ICompanyRepository Company {
            get {
                if (_companyRepository == null)
                _companyRepository = new CompanyRepository(_db);

                return _companyRepository;
            }
        }

        public IEmployeeRepository Employee {
            get {
                if (_employeeRepository == null)
                _employeeRepository = new EmployeeRepository(_db);

                return _employeeRepository;
            }
        }

        public void Save() => _db.SaveChanges();
    }
}