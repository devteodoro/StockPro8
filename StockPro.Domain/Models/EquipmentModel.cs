
namespace StockPro.Domain.Models
{
    public class EquipmentModel : BaseEntity
    {
        // Nome do modelo do equipamento
        public string Name { get; set; } = string.Empty;

        // Descrição detalhada do modelo
        public string Description { get; set; } = string.Empty;

        // Fabricante ou marca do equipamento
        public string? Brand { get; set; }

        // Tipo específico do equipamento (ex: compressor, gerador)
        public string? EquipmentType { get; set; }

        // Peso do equipamento
        public double? Weight { get; set; }

        // Tensão de operação do equipamento (ex: 110V, 220V)
        public string? OperatingVoltage { get; set; }

        // Frequência elétrica (ex: 50Hz, 60Hz)
        public string? OperatingFrequency { get; set; }

        // Material principal do equipamento (ex: aço inoxidável, plástico)
        public string? Material { get; set; }

        // Tempo de vida útil estimado do equipamento
        public int? EstimatedLifespan { get; set; }

        // Tempo ou condição recomendada para manutenções periódicas
        public string? RecommendedMaintenanceInterval { get; set; }

        // Links ou arquivos de manuais técnicos, guias de uso, etc.
        public string? TechnicalDocumentation { get; set; }

        public ICollection<Equipment>? Equipments { get; set; }
    }
}
