using Microsoft.EntityFrameworkCore;
using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;
using StockPro.Infrastructure.Data;

namespace StockPro.Infrastructure.Repositories
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly StockProDataContext _dbContext;

        public ServiceRequestRepository(StockProDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ServiceRequest> CreateAsync(ServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRequest> DeleteAsync(ServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceRequest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRequest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRequest> UpdateAsync(ServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<ServiceRequest>> GetAllAsync() => await _dbContext.ServiceRequests.ToListAsync();

        //public async Task<ServiceRequest> GetByIdAsync(int id) => await _dbContext.ServiceRequests.FirstOrDefaultAsync(x => x.Id == id);

        //public async Task<ServiceRequest> CreateAsync(ServiceRequest serviceRequest)
        //{
        //    await _dbContext.ServiceRequests.AddAsync(serviceRequest);
        //    await _dbContext.SaveChangesAsync();
        //    return serviceRequest;
        //}

        //public async Task<ServiceRequest> DeleteAsync(ServiceRequest serviceRequest)
        //{
        //    _dbContext.ServiceRequests.Remove(serviceRequest);
        //    await _dbContext.SaveChangesAsync();
        //    return serviceRequest;
        //}

        //public async Task<ServiceRequest> UpdateAsync(ServiceRequest serviceRequest)
        //{
        //    _dbContext.ServiceRequests.Update(serviceRequest);
        //    await _dbContext.SaveChangesAsync();
        //    return serviceRequest;
        //}
    }
}
