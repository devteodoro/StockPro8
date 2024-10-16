

namespace StockPro.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? FantasyName { get; set; }

        public string CNPJ { get; set; } = string.Empty;

        public ICollection<Address>? Addresses { get; set; }

        public ICollection<Contact>? Contacts { get; set; }

        public ICollection<ServiceRequest>? ServiceRequests { get; set; }

        public ICollection<ServiceOrder>? ServiceOrders { get; set; }

        public Client() { }

        public Client(string name, string? fantasyName, string cnpj)
        {
            Name = name;
            FantasyName = fantasyName;
            CNPJ = cnpj;
            Addresses = new List<Address>();
            Contacts = new List<Contact>();
            ServiceRequests = new List<ServiceRequest>();
            ServiceOrders = new List<ServiceOrder>();
        }

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
