using Microsoft.AspNetCore.Mvc;
using StockPro.Application.DTO;
using StockPro.Application.Interfaces;
using StockPro.ViewModels.Client;

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
                    throw new Exception($"Empresa não encontrada!");

                UpdateClientViewModel model = new();

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

                };

                //if (!string.IsNullOrEmpty(model.CNPJ))
                //{
                //    if (!ValidationCNPJ.IsValidCNPJ(model.CNPJ))
                //        throw new Exception("CNPJ invalido!");

                //    company.CNPJ = model.CNPJ;
                //}

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

                ClientDTO clientDto = new();

                //company.Name = model.Name;
                //company.Email = model.Email;
                //company.Site = model.Site;
                //company.ZipCode = model.ZipCode;
                //company.State = model.State;
                //company.City = model.City;
                //company.Address = model.Address;
                //company.Number = model.Number;
                //company.Complement = model.Complement;
                //company.ImageBase64 = model.ImageBase64;

                //if (!string.IsNullOrEmpty(model.CNPJ))
                //{
                //    if (!ValidationCNPJ.IsValidCNPJ(model.CNPJ))
                //        throw new Exception("CNPJ invalido!");

                //    company.CNPJ = model.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                //}

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
