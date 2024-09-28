
namespace StockPro.Domain.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string CNPJ { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Site { get; set; }

        public string? ZipCode { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

        public string? ImageBase64 { get; set; }

        public List<WorkCenter>? WorkCenters { get; set; }
    }
}
