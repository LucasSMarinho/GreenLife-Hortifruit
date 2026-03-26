using System.ComponentModel.DataAnnotations;

namespace GreenLife.WebAPI.DTO
{
    public class FornecedorDTO
    {
        [Required(ErrorMessage = "O Titulo da categoria é obrigatória")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "O Titulo da categoria é obrigatória")]
        public string? Cnpj {  get; set; }
    }
}
