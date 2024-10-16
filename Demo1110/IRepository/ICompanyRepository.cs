using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1110.Model;

namespace Demo1110.Repository
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);

        Company GetCompany(Guid companyId, bool trackChanges);

        void CreateCompany(Company company);

        IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteCompany(Company company);
    }
}