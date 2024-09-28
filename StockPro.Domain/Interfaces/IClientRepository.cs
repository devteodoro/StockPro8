using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int id);

        Task<List<Client>> GetAllAsync();

        Task<Client> CreateAsync(Client client);

        Task<Client> UpdateAsync(Client client);

        Task<Client> DeleteAsync(Client client);
    }
}
