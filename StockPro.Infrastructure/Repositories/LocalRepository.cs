using Microsoft.EntityFrameworkCore;
using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;
using StockPro.Infrastructure.Data;

namespace StockPro.Infrastructure.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly StockProDataContext _dbContext;

        public LocalRepository(StockProDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Local>> GetAllAsync() => await _dbContext.Locals.ToListAsync();

        public async Task<Local> GetByIdAsync(int id) => await _dbContext.Locals.Include(x => x.Equipments).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Local> CreateAsync(Local local)
        {
            await _dbContext.Locals.AddAsync(local);
            await _dbContext.SaveChangesAsync();
            return local;
        }

        public async Task<Local> UpdateAsync(Local local)
        {
            _dbContext.Locals.Update(local);
            await _dbContext.SaveChangesAsync();
            return local;
        }

        public async Task<Local> DeleteAsync(Local local)
        {
            _dbContext.Locals.Remove(local);
            await _dbContext.SaveChangesAsync();
            return local;
        }
    }
}
