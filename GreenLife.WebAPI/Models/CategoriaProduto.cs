using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GreenLife.WebAPI.Models;

[Table("CategoriaProduto")]
public partial class CategoriaProduto
{
    [Key]
    public Guid IdCategoriaProduto { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("IdCategoriaProdutoNavigation")]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
