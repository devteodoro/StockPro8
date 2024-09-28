
using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IServiceOrderRepository
    {
        Task<ServiceOrder> GetByIdAsync(int id);

        Task<List<ServiceOrder>> GetAllAsync();

        Task<ServiceOrder> CreateAsync(ServiceOrder serviceOrder);

        Task<ServiceOrder> UpdateAsync(ServiceOrder serviceOrder);

        Task<ServiceOrder> DeleteAsync(ServiceOrder serviceOrder);
    }
}
