using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task<Company> CreateAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Company> DeleteAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
