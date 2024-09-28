using Microsoft.EntityFrameworkCore;
using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;
using StockPro.Infrastructure.Data;
using System;

namespace StockPro.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {

        public readonly StockProDataContext _dbContext;

        public ClientRepository(StockProDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Client>> GetAllAsync() => await _dbContext.Clients.ToListAsync();

        public async Task<Client> GetByIdAsync(int id) => await _dbContext.Clients.Include(x => x.Addresses).Include(x => x.Contacts).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Client> CreateAsync(Client client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteAsync(Client client)
        {
            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }
    }
}
