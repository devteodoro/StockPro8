
namespace StockPro.Domain.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public Contact() { }

        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public Contact(string name, string email, string phone, int clientId, Client client)
        {
            Name = name;
            Email = email;
            Phone = phone;
            ClientId = clientId;
            Client = client;
        }
    }
}
