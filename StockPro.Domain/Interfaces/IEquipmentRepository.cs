
using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<Equipment> GetByIdAsync(int id);

        Task<List<Equipment>> GetAllAsync();

        Task<Equipment> CreateAsync(Equipment equipment);

        Task<Equipment> UpdateAsync(Equipment equipment);

        Task<Equipment> DeleteAsync(Equipment equipment);
    }
}
