

namespace StockPro.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string FantasyName { get; set; } = string.Empty;

        public string CNPJ { get; set; } = string.Empty;

        public ICollection<Address>? Addresses { get; set; }

        public ICollection<Contact>? Contacts { get; set; }

        public ICollection<ServiceRequest>? ServiceRequests { get; set; }

        public ICollection<ServiceOrder>? ServiceOrders { get; set; }
    }
}
