
namespace StockPro.Domain.Models
{
    public class ServiceOrderTechnical : BaseEntity
    {
        public int ServiceOrderId { get; set; }

        public ServiceOrder ServiceOrder { get; set; } = new();

        public int TechnicalId { get; set; }

        public Technical Technical { get; set; } = new();

        public int FunctionId { get; set; }

        public JobFunction Function { get; set; } = new();

        public ICollection<WorkHours>? WorkHours { get; set; }
    }
}
