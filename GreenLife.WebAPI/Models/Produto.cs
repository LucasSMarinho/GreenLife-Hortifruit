using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GreenLife.WebAPI.Models;

[Table("Produto")]
[Index("Nome", Name = "UQ__Produto__7D8FE3B2AA06AD0F", IsUnique = true)]
public partial class Produto
{
    [Key]
    public Guid IdProduto { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Preco { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    public Guid? IdCategoriaProduto { get; set; }

    public Guid? IdFornecedor { get; set; }

    [ForeignKey("IdCategoriaProduto")]
    [InverseProperty("Produtos")]
    public virtual CategoriaProduto? IdCategoriaProdutoNavigation { get; set; }

    [ForeignKey("IdFornecedor")]
    [InverseProperty("Produtos")]
    public virtual Fornecedor? IdFornecedorNavigation { get; set; }
}
