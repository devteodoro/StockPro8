using StockPro.Domain.Enums;

namespace StockPro.Domain.Models
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string TAG { get; set; } = string.Empty;

        public string? SerialNumber { get; set; }

        public string? Description { get; set; }

        public StatusAssets Status { get; set; }

        // Custo de aquisição do equipamento
        public decimal? AcquisitionCost { get; set; }

        public int EquipmentModelId { get; set; }

        public EquipmentModel EquipmentModel { get; set; } = new();

        public int LocalId { get; set; }

        public Local? Local { get; set; }

        public ICollection<ServiceRequest>? ServiceRequests { get; set; }

        public ICollection<ServiceOrder>? ServiceOrders { get; set; }
    }
}
