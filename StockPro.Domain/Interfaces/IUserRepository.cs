using StockPro.Domain.Models;

namespace StockPro.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetByLoginAsync(string login);

        Task<User> GetByLoginAndEmailAsync(string login, string email);

        Task<List<User>> GetAllAsync();

        Task<User> CreateAsync(User user);

        Task<User> UpdateAsync(User user);

        Task<User> DeleteAsync(User user);

        Task<User> ChangePassawordAsync(User model);
    }
}
