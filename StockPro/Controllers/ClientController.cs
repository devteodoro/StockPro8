using Microsoft.AspNetCore.Mvc;
using StockPro.Application.DTO;
using StockPro.Application.Interfaces;
using StockPro.ViewModels.Client;
using StockPro.ViewModels.Address;
using StockPro.ViewModels.Contact;

namespace StockPro.Controllers
{
    public class ClientController : Controller
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            List<ClientDTO> clients = await _clientService.GetAllClientAsync();

            if (clients == null)
                return View(null);

            List<ClientViewModel> viewModels = new();

            foreach (ClientDTO client in clients)
            {
                viewModels.Add(new ClientViewModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    CNPJ = client.CNPJ,
                    FantasyName = client.FantasyName
                });
            }

            return View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                ClientDTO clientDto = await _clientService.GetClientByIdAsync(id);

                if (clientDto == null)
                    throw new Exception($"Cliente não encontrada!");

                UpdateClientViewModel model = new();

                model.Id = clientDto.Id;
                model.Name = clientDto.Name;
                model.CNPJ = clientDto.CNPJ;
                model.FantasyName = clientDto.FantasyName;

                foreach (AddressDTO addressDto in clientDto.AddressesDTO)
                {
                    model.Addresses.Add(new UpdateAddressViewModel
                    {
                        Id = addressDto.Id,
                        ZipCode = addressDto.ZipCode,
                        Country = addressDto.Country,
                        State = addressDto.State,
                        City = addressDto.City,
                        Street = addressDto.Street,
                        Number = addressDto.Number,
                        Complement = addressDto.Complement
                    });
                }

                foreach (ContactDTO contactDto in clientDto.ContactsDTO)
                {
                    model.Contacts.Add(new UpdateContactViewModel
                    {
                        Id = contactDto.Id,
                        Name = contactDto.Name,
                        Email = contactDto.Email,
                        Phone = contactDto.Phone
                    });
                }

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ocorreu um erro. Detalhes: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClientViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Dados invalidos!");

                ClientDTO ClientDto = new ClientDTO()
                {
                    Name = model.Name,
                    CNPJ = model.CNPJ,
                    FantasyName = model.FantasyName
                };

                foreach (CreateAddressViewModel address in model.Addresses)
                {
                    ClientDto
                        .AddressesDTO
                        .Add(new AddressDTO
                        {
                            ZipCode = address.ZipCode,
                            Country = address.Country,
                            State = address.State,
                            City = address.City,
                            Street = address.Street,
                            Number = address.Number,
                            Complement = address.Complement
                        });
                }

                foreach (CreateContactViewModel contact in model.Contacts)
                {
                    ClientDto
                        .ContactsDTO
                        .Add(new ContactDTO
                        {
                            Name = contact.Name,
                            Email = contact.Email,
                            Phone = contact.Phone
                        });
                }

                ClientDTO clientDto = await _clientService.CreateClientAsync(ClientDto);

                TempData["SuccessMessage"] = $"Cliente  cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ocorreu um erro. Detalhes: {ex.Message}";
                return View("Create");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateClientViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Dados invalidos!");

                ClientDTO clientDto = new ClientDTO()
                {
                    Name = model.Name,
                    CNPJ = model.CNPJ,
                    FantasyName = model.FantasyName
                };

                foreach (UpdateAddressViewModel address in model.Addresses)
                {
                    clientDto
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

                foreach (UpdateContactViewModel contact in model.Contacts)
                {
                    clientDto
                        .ContactsDTO
                        .Add(new ContactDTO
                        {
                            Id = contact.Id,
                            Name = contact.Name,
                            Email = contact.Email,
                            Phone = contact.Phone
                        });
                }

                ClientDTO client = await _clientService.UpdateClientAsync(clientDto);

                TempData["SuccessMessage"] = $"Cliente alterado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ocorreu um erro. Detalhes: {ex.Message}";
                return View("Edit", model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Comando invalido!");

                await _clientService.DeleteClientAsync(id);

                TempData["SuccessMessage"] = $"Cliente excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ocorreu um erro. Detalhes: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
