

namespace StockPro.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? FantasyName { get; set; }

        public string CNPJ { get; set; } = string.Empty;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        public ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

        public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

        public Client() { }

        public Client(string name, string? fantasyName, string cNPJ, ICollection<Address> addresses, ICollection<Contact> contacts, ICollection<ServiceRequest> serviceRequests, ICollection<ServiceOrder> serviceOrders)
        {
            Name = name;
            FantasyName = fantasyName;
            CNPJ = cNPJ;
            Addresses = addresses;
            Contacts = contacts;
            ServiceRequests = serviceRequests;
            ServiceOrders = serviceOrders;
        }
    }
}
