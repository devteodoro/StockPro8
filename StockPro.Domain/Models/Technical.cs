namespace StockPro.Domain.Models
{
    public class Technical : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public JobFunction? Function { get; set; }
    }
}
