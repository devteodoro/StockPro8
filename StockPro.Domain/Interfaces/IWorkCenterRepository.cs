using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IWorkCenterRepository
    {
        Task<WorkCenter> GetByIdAsync(int id);

        Task<List<WorkCenter>> GetAllAsync();

        Task<WorkCenter> CreateAsync(WorkCenter workCenter);

        Task<WorkCenter> UpdateAsync(WorkCenter workCenter);

        Task<WorkCenter> DeleteAsync(WorkCenter workCenter);
    }
}
