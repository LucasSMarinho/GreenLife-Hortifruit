using System.ComponentModel.DataAnnotations;

namespace GreenLife.WebAPI.DTO
{
    public class CategoriaProdutoDTO
    {
        [Required(ErrorMessage = "O Titulo da categoria é obrigatória")]
        public string? Titulo { get; set; }
    }
}
