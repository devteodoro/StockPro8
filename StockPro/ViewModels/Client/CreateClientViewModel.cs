using StockPro.ViewModels.Address;
using StockPro.ViewModels.Contact;
using System.ComponentModel.DataAnnotations;

namespace StockPro.ViewModels.Client
{
    public class CreateClientViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Nome fantasia")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O nome fantasia deve ter no máximo 100 caracteres.")]
        public string FantasyName { get; set; } = string.Empty;

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(14, MinimumLength = 0, ErrorMessage = "O CNPJ deve ter no máximo 14 caracteres.")]
        public string CNPJ { get; set; } = string.Empty;

        // Coleção de Endereços
        public List<CreateAddressViewModel> Addresses { get; set; } = new();

        // Coleção de Contatos
        public List<CreateContactViewModel> Contacts { get; set; } = new();
    }
}
