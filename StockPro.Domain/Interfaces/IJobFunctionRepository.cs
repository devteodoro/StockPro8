using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IJobFunctionRepository
    {
        Task<JobFunction> GetByIdAsync(int id);

        Task<List<JobFunction>> GetAllAsync();

        Task<JobFunction> CreateAsync(JobFunction function);

        Task<JobFunction> UpdateAsync(JobFunction function);

        Task<JobFunction> DeleteAsync(JobFunction function);
    }
}
