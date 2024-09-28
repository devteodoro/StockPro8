
namespace StockPro.Domain.Models
{
    public class ServiceOrderTechnical : BaseEntity
    {
        public Technical Technical { get; set; } = new();

        public JobFunction Job { get; set; } = new();

        public ICollection<WorkHours> WorkHours { get; set; }
    }
}
