using System.ComponentModel.DataAnnotations;

namespace GreenLife.WebAPI.DTO
{
    public class FornecedorDTO
    {
        [Required(ErrorMessage = "O Nome fantasia do fornecedor é obrigatória")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "O Cnpj do fornecedor é obrigatória")]
        public string? Cnpj {  get; set; }
    }
}
