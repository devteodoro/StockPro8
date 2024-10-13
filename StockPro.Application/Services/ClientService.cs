using StockPro.Application.DTO;
using StockPro.Application.Interfaces;
using StockPro.Domain.Interfaces;
using StockPro.Domain.Models;

namespace StockPro.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDTO>> GetAllClientAsync()
        {
            List<Client> clients = await _clientRepository.GetAllAsync();

            List<ClientDTO> clientsDTO = new();

            if (clients != null)
            {
                foreach (var client in clients)
                {
                    clientsDTO.Add(new ClientDTO
                    {
                        Id = client.Id,
                        Name = client.Name,
                        CNPJ = client.CNPJ,
                        FantasyName = client.FantasyName
                    });
                }
            }

            return clientsDTO;
        }

        public async Task<ClientDTO> GetClientByIdAsync(int Id)
        {
            Client client = await _clientRepository.GetByIdAsync(Id);

            if (client == null)
                throw new Exception("Cliente não encontrado!");

            ClientDTO dto = new();

            dto.Id = client.Id;
            dto.Name = client.Name;
            dto.CNPJ = client.CNPJ;
            dto.FantasyName = client.FantasyName;

            foreach (Address address in client.Addresses)
            {
                dto
                    .AddressesDTO
                    .Add(new AddressDTO
                    {
                        Id = address.Id,
                        ZipCode = address.ZipCode,
                        Country = address.Country,
                        State = address.State,
                        City = address.City,
                        Street = address.Street,
                        Number = address.Number,
                        Complement = address.Complement
                    });
            }

            foreach (Contact contact in client.Contacts)
            {
                dto
                    .ContactsDTO
                    .Add(new ContactDTO
                    {
                        Id = contact.Id,
                        Name = contact.Name,
                        Email = contact.Email,
                        Phone = contact.Phone
                    });
            }

            return dto;
        }

        public async Task<ClientDTO> CreateClientAsync(ClientDTO clientDTO)
        {

            if (string.IsNullOrEmpty(clientDTO.Name))
                throw new Exception("O nome do cliente é obrigatório!");

            if (string.IsNullOrEmpty(clientDTO.CNPJ))
                throw new Exception("O CNPJ do cliente é obrigatório!");

            Client client = new Client
            {
                Name = clientDTO.Name,
                CNPJ = clientDTO.CNPJ,
                FantasyName = clientDTO.FantasyName
            };

            if (clientDTO.AddressesDTO.Count > 0)
            {
                foreach (AddressDTO addressDto in clientDTO.AddressesDTO)
                {
                    client.Addresses.Add(
                        new Address(
                            addressDto.ZipCode,
                            addressDto.Country,
                            addressDto.State,
                            addressDto.City,
                            addressDto.Street,
                            addressDto.Number,
                            addressDto.Complement));
                }
            }

            if (clientDTO.ContactsDTO.Count > 0)
            {
                foreach (ContactDTO contactDto in clientDTO.ContactsDTO)
                {
                    client.Contacts.Add(
                        new Contact(
                            contactDto.Name,
                            contactDto.Email,
                            contactDto.Phone));
                }
            }

            await _clientRepository.CreateAsync(client);
            return clientDTO;
        }

        public async Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO)
        {
            Client client = await _clientRepository.GetByIdAsync(clientDTO.Id);

            if (client == null)
                throw new Exception("Cliente não encontrado!");

            if (string.IsNullOrEmpty(clientDTO.Name))
                throw new Exception("O nome do cliente é obrigatório!");

            if (string.IsNullOrEmpty(clientDTO.CNPJ))
                throw new Exception("O CNPJ do cliente é obrigatório!");

            client.Name = clientDTO.Name;
            client.CNPJ = clientDTO.CNPJ;
            client.FantasyName = clientDTO.FantasyName;

            if (clientDTO.AddressesDTO.Count > 0)
            {
                foreach (AddressDTO addressDto in clientDTO.AddressesDTO)
                {
                    if (addressDto.Id <= 0)
                    {
                        client.Addresses.Add(
                                            new Address(
                                                addressDto.ZipCode,
                                                addressDto.Country,
                                                addressDto.State,
                                                addressDto.City,
                                                addressDto.Street,
                                                addressDto.Number,
                                                addressDto.Complement));
                        continue;
                    }

                    Address address = client.Addresses.FirstOrDefault(x => x.Id == addressDto.Id);

                    if (address != null)
                    {
                        address.ZipCode = addressDto.ZipCode;
                        address.Country = addressDto.Country;
                        address.State = addressDto.State;
                        address.City = addressDto.City;
                        address.Street = addressDto.Street;
                        address.Number = addressDto.Number;
                        address.Complement = addressDto.Complement;
                        continue;
                    }
                }

                foreach (Address address in client.Addresses)
                {
                    AddressDTO dto = clientDTO.AddressesDTO.FirstOrDefault(x => x.Id == address.Id);

                    if (dto == null)
                        client.Addresses.Remove(address);
                }
            }

            if (clientDTO.ContactsDTO.Count > 0)
            {
                foreach (ContactDTO contactDto in clientDTO.ContactsDTO)
                {
                    if (contactDto.Id <= 0)
                    {
                        client.Contacts.Add(
                                            new Contact(
                                                contactDto.Name,
                                                contactDto.Email,
                                                contactDto.Phone));

                        continue;
                    }

                    Contact contact = client.Contacts.FirstOrDefault(x => x.Id == contactDto.Id);

                    if (contact != null)
                    {
                        contact.Name = contactDto.Name;
                        contact.Email = contactDto.Email;
                        contact.Phone = contactDto.Phone;
                        continue;
                    }
                }

                foreach (Contact contact in client.Contacts)
                {
                    ContactDTO dto = clientDTO.ContactsDTO.FirstOrDefault(x => x.Id == contact.Id);

                    if (dto == null)
                        client.Contacts.Remove(contact);
                }
            }

            await _clientRepository.UpdateAsync(client);
            return clientDTO;
        }

        public async Task DeleteClientAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException("Id de usuário invalido!");

            Client client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
                throw new Exception("Cliente não encontrado!");

            await _clientRepository.DeleteAsync(client);
        }
    }
}
