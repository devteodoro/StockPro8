
using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface ILocalRepository
    {
        Task<Local> GetByIdAsync(int id);

        Task<List<Local>> GetAllAsync();

        Task<Local> CreateAsync(Local local);

        Task<Local> UpdateAsync(Local local);

        Task<Local> DeleteAsync(Local local);
    }
}
