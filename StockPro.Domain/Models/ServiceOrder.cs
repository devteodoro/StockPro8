using StockPro.Domain.Enums;

namespace StockPro.Domain.Models
{
    public class ServiceOrder : BaseEntity
    {
        public string CodeServiceOrder { get; set; } = string.Empty;

        //boolean para controlar se o ativo está cadastrado no banco de dados
        public bool RegisteredAsset { get; set; }

        //Id do local
        public int? LocalId { get; set; }

        //id do Local cadastrado
        public Local? Local { get; set; }

        //Id do equipamento
        public int? EquipamentId { get; set; }

        //id do Equipamento cadastrado
        public Equipment? Equipment { get; set; }

        //Nome do local não cadastrado
        public string? LocalNotRegistered { get; set; }

        //Nome do equipamento não cadastrado
        public string? EquipmentNotRegistered { get; set; }

        //Id do cliente
        public int? ClientId { get; set; }

        //dados do cliente que possui o equipamento e precisa de manutenção
        public Client? Client { get; set; }

        //descrição do problema 
        public string? Description { get; set; }

        //Status da ordem de serviço    
        public StatusServiceOrder Status { get; set; }

        //Data estimada de inicio do serviço
        public DateTime? EstimatedStartDate { get; set; }

        //Data real de inicio do serviço
        public DateTime? StartDate { get; set; }

        //Data estimada de fim do serviço
        public DateTime? EstimatedEndDate { get; set; }

        //Data real de fim do serviço
        public DateTime? EndDate { get; set; }

        //Criticidade do serviço
        public Criticality Criticality { get; set; }

        //Valor estimado pelo serviço
        public double? EstimatedValue { get; set; }

        //Comentários 
        public string? Comments { get; set; }

        //Feedback do cliente 
        public string? ClientFeedback { get; set; }

        //Objeto nota de serviço que gerou essa ordem (Um ordem pode ser criada sem uma solicitação de serviço)
        public ServiceRequest? ServiceRequest { get; set; }
    }
}
