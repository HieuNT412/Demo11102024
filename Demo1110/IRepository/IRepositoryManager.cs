using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1110.Repository;

namespace Demo1110.IRepository
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company {get;}
        IEmployeeRepository Employee {get;}
        void Save();
    }
}