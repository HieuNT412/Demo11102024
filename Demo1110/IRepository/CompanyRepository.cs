using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1110.Model;
using Demo1110.Repository;

namespace Demo1110.IRepository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext db) : base(db)
        {
        }

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) {Delete(company);}

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) => FindByCondition(x => ids.Contains(x.Id), trackChanges);

        public Company GetCompany(Guid companyId, bool trackChanges) => FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
    }
}