using System.ComponentModel.DataAnnotations;

namespace GreenLife.WebAPI.DTO
{
    public class produtoDTOAtualizar
    {
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public IFormFile? Imagem { get; set; }
        public Guid? IdFornecedor { get; set; }
        public Guid? IdCategoriaProduto { get; set; }
    }
}
