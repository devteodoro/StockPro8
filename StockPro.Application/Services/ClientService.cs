using StockPro.Application.DTO;
using StockPro.Application.Interfaces;
using StockPro.Domain.Interfaces;

namespace StockPro.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<List<ClientDTO>> GetAllClientAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> GetClientByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> CreateClientAsync(ClientDTO Id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> DeleteClientAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> UpdateClientAsync(ClientDTO Id)
        {
            throw new NotImplementedException();
        }
    }
}
