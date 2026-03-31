using System.ComponentModel.DataAnnotations;

namespace GreenLife.WebAPI.DTO
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "O Cnpj do fornecedor é obrigatória")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O Cnpj do fornecedor é obrigatória")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "O Cnpj do fornecedor é obrigatória")]
        public IFormFile? Imagem{ get; set; }


        [Required(ErrorMessage = "O Cnpj do fornecedor é obrigatória")]
        public Guid IdFornecedor { get; set; }


        [Required(ErrorMessage = "O Cnpj do fornecedor é obrigatória")]
        public Guid IdCategoriaProduto { get; set; }
    }
}
