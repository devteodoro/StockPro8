using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface ITechnicalRepository
    {
        Task<Technical> GetByIdAsync(int id);

        Task<List<Technical>> GetAllAsync();

        Task<Technical> CreateAsync(Technical technical);

        Task<Technical> UpdateAsync(Technical technical);

        Task<Technical> DeleteAsync(Technical technical);
    }
}
