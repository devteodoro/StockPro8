
namespace StockPro.Application.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FantasyName { get; set; } = string.Empty;

        public string CNPJ { get; set; } = string.Empty;

        public List<AddressDTO> AddressesDTO { get; set; } = new();

        public List<ContactDTO> ContactsDTO { get; set; } = new();
    }
}
