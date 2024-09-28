
namespace StockPro.Domain.Models
{
    public class Address : BaseEntity
    {
        public string ZipCode { get; set; } = string.Empty;

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; } = new();
    }
}
