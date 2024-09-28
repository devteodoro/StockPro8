
namespace StockPro.Domain.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public Client Client { get; set; } = new();
    }
}
