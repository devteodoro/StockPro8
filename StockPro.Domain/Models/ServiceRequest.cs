using StockPro.Domain.Enums;

namespace StockPro.Domain.Models
{
    public class ServiceRequest : BaseEntity
    {
        // Data do ocorrido
        public DateTime DateOccurrence { get; set; }

        //boolean para controlar se o ativo está cadastrado no banco de dados
        public bool RegisteredAsset { get; set; }

        // Ativo parado ou inativo
        public bool InactiveAsset { get; set; }

        //Id do local
        public int? LocalId { get; set; }

        //Objeto Local cadastrado
        public Local? Local { get; set; }

        //Id do equipamento
        public int? EquipamentId { get; set; }

        //Objeto Equipamento cadastrado
        public Equipment? Equipment { get; set; }

        //Nome do local não cadastrado
        public string? LocalNotRegistered { get; set; }

        //Nome do equipamento não cadastrado
        public string? EquipmentNotRegistered { get; set; }

        public int? ClientId { get; set; }

        //dados do cliente que possui o equipamento e precisa de manutenção
        public Client? Client { get; set; }

        //Descrição do problema 
        public string Description { get; set; } = string.Empty;

        public int RequesterId { get; set; }

        //Usuário que solicitou o serviço
        public User Requester { get; set; } = new();

        //Criticidade do serviço
        public Criticality Criticality { get; set; }

        //Status da solicitação do serviço
        public StatusServiceRequest Status { get; set; }

        public ServiceOrder? ServiceOrder { get; set; }
    }
}
