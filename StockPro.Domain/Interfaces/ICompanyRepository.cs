using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(int id);

        Task<List<Company>> GetAllAsync();

        Task<Company> CreateAsync(Company company);

        Task<Company> UpdateAsync(Company company);

        Task<Company> DeleteAsync(Company company);
    }
}
