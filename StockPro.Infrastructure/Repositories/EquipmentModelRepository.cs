
using Microsoft.EntityFrameworkCore;
using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;
using StockPro.Infrastructure.Data;

namespace StockPro.Infrastructure.Repositories
{
    public class EquipmentModelRepository : IEquipmentModelRepository
    {
        public readonly StockProDataContext _dbContext;

        public EquipmentModelRepository(StockProDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EquipmentModel>> GetAllAsync() => await _dbContext.EquipmentModels.ToListAsync();

        public async Task<EquipmentModel> GetByIdAsync(int id) => await _dbContext.EquipmentModels.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<EquipmentModel> CreateAsync(EquipmentModel equipmentModel)
        {
            await _dbContext.EquipmentModels.AddAsync(equipmentModel);
            await _dbContext.SaveChangesAsync();
            return equipmentModel;
        }

        public async Task<EquipmentModel> UpdateAsync(EquipmentModel equipmentModel)
        {
            _dbContext.EquipmentModels.Update(equipmentModel);
            await _dbContext.SaveChangesAsync();
            return equipmentModel;
        }

        public async Task<EquipmentModel> DeleteAsync(EquipmentModel equipmentModel)
        {
            _dbContext.EquipmentModels.Remove(equipmentModel);
            await _dbContext.SaveChangesAsync();
            return equipmentModel;
        }
    }
}
