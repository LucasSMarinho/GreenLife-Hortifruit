using System.ComponentModel.DataAnnotations;

namespace GreenLife.WebAPI.DTO
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "O Imagem é obrigatória")]
        public IFormFile? Imagem{ get; set; }


        [Required(ErrorMessage = "O id do fornecedor é obrigatório")]
        public Guid IdFornecedor { get; set; }


        [Required(ErrorMessage = "O id da categoria é obrigatório")]
        public Guid IdCategoriaProduto { get; set; }
    }
}
