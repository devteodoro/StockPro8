using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IServiceRequestRepository
    {
        Task<ServiceRequest> GetByIdAsync(int id);

        Task<List<ServiceRequest>> GetAllAsync();

        Task<ServiceRequest> CreateAsync(ServiceRequest serviceRequest);

        Task<ServiceRequest> UpdateAsync(ServiceRequest serviceRequest);

        Task<ServiceRequest> DeleteAsync(ServiceRequest serviceRequest);
    }
}