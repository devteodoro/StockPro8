namespace StockPro.Domain.Models
{
    public class Deposit : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? ZipCode { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

        public int? WorkcenterId { get; set; }

        public WorkCenter? WorkCenter { get; set; }
    }
}
