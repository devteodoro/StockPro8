
using Microsoft.EntityFrameworkCore;
using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;
using StockPro.Infrastructure.Data;

namespace StockPro.Infrastructure.Repositories
{
    public class JobRepository : IJobFunctionRepository
    {
        public readonly StockProDataContext _dbContext;

        public JobRepository(StockProDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<JobFunction> CreateAsync(JobFunction function)
        {
            throw new NotImplementedException();
        }

        public Task<JobFunction> DeleteAsync(JobFunction function)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobFunction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JobFunction> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JobFunction> UpdateAsync(JobFunction function)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<JobFunction>> GetAllAsync() => await _dbContext.Functions.ToListAsync();

        //public async Task<JobFunction> GetByIdAsync(int id) => await _dbContext.Functions.FirstOrDefaultAsync(x => x.Id == id);

        //public async Task<JobFunction> CreateAsync(JobFunction function)
        //{
        //    await _dbContext.Functions.AddAsync(function);
        //    await _dbContext.SaveChangesAsync();
        //    return function;
        //}

        //public async Task<JobFunction> UpdateAsync(JobFunction function)
        //{
        //    _dbContext.Functions.Update(function);
        //    await _dbContext.SaveChangesAsync();
        //    return function;
        //}

        //public async Task<JobFunction> DeleteAsync(JobFunction function)
        //{
        //    _dbContext.Functions.Remove(function);
        //    await _dbContext.SaveChangesAsync();
        //    return function;
        //}
    }
}
