using StockPro.Application.DTO;


namespace StockPro.Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDTO>> GetAllClientAsync();

        Task<ClientDTO> GetClientByIdAsync(int Id);

        Task<ClientDTO> CreateClientAsync(ClientDTO Id);

        Task<ClientDTO> UpdateClientAsync(ClientDTO Id);

        Task<ClientDTO> DeleteClientAsync(int Id);
    }
}
