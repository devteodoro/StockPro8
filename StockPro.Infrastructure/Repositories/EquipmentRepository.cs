
using Microsoft.EntityFrameworkCore;
using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;
using StockPro.Infrastructure.Data;

namespace StockPro.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public readonly StockProDataContext _dbContext;

        public EquipmentRepository(StockProDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Equipment>> GetAllAsync() => await _dbContext.Equipments.ToListAsync();

        public async Task<Equipment> GetByIdAsync(int id) => await _dbContext.Equipments.Include(x => x.EquipmentModel).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Equipment> CreateAsync(Equipment equipment)
        {
            await _dbContext.Equipments.AddAsync(equipment);
            await _dbContext.SaveChangesAsync();
            return equipment;
        }

        public async Task<Equipment> UpdateAsync(Equipment equipment)
        {
            _dbContext.Equipments.Update(equipment);
            await _dbContext.SaveChangesAsync();
            return equipment;
        }

        public async Task<Equipment> DeleteAsync(Equipment equipment)
        {
            _dbContext.Equipments.Remove(equipment);
            await _dbContext.SaveChangesAsync();
            return equipment;
        }
    }
}
