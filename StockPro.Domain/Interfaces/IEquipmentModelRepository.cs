
using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IEquipmentModelRepository
    {
        Task<EquipmentModel> GetByIdAsync(int id);

        Task<List<EquipmentModel>> GetAllAsync();

        Task<EquipmentModel> CreateAsync(EquipmentModel equipmentModel);

        Task<EquipmentModel> UpdateAsync(EquipmentModel equipmentModel);

        Task<EquipmentModel> DeleteAsync(EquipmentModel equipmentModel);
    }
}
