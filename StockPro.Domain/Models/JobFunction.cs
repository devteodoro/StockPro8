namespace StockPro.Domain.Models
{
    public class JobFunction : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double? HourlyRate { get; set; }

        public int? TechnicalId { get; set; }

        public Technical? Technical { get; set; }

        public ICollection<ServiceOrderTechnical>? ServiceOrderTechnicals { get; set; }
    }
}
