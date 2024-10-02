using StockPro.Domain.Enums;

namespace StockPro.Domain.Models
{
    public class Local : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string TAG { get; set; } = string.Empty;

        public string? Description { get; set; }

        public StatusAssets Status { get; set; }

        public ICollection<Equipment>? Equipments { get; set; }

        public ICollection<ServiceRequest>? ServiceRequests { get; set; }

        public ICollection<ServiceOrder>? ServiceOrders { get; set; }
    }
}
