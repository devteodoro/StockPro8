namespace StockPro.Domain.Models
{
    public class WorkHours : BaseEntity
    {
        public int ServiceOrderTechnicalId { get; set; }

        public ServiceOrderTechnical ServiceOrderTechnical { get; set; } = new();

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? RealStartDate { get; set; }

        public DateTime? RealEndDate { get; set; }
    }
}
