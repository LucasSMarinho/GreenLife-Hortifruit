using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GreenLife.WebAPI.Models;

[Table("Fornecedor")]
[Index("Cnpj", Name = "UQ__Forneced__AA57D6B497AE4E1C", IsUnique = true)]
[Index("NomeFantasia", Name = "UQ__Forneced__F5389F3180A81FB8", IsUnique = true)]
public partial class Fornecedor
{
    [Key]
    public Guid IdFornecedor { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NomeFantasia { get; set; } = null!;

    [Column("CNPJ")]
    [StringLength(14)]
    [Unicode(false)]
    public string Cnpj { get; set; } = null!;

    [InverseProperty("IdFornecedorNavigation")]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
