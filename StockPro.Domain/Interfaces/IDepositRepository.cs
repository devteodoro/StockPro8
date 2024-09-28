using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IDepositRepository
    {
        Task<Deposit> GetByIdAsync(int id);

        Task<List<Deposit>> GetAllAsync();

        Task<Deposit> CreateAsync(Deposit deposit);

        Task<Deposit> UpdateAsync(Deposit deposit);

        Task<Deposit> DeleteAsync(Deposit deposit);
    }
}
