using System;
using System.Collections.Generic;
using GreenLife.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenLife.WebAPI.BdContextGreenLife;

public partial class GreenLifeContext : DbContext
{
    public GreenLifeContext()
    {
    }

    public GreenLifeContext(DbContextOptions<GreenLifeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaProduto> CategoriaProdutos { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GreenLifeH;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaProduto>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaProduto).HasName("PK__Categori__76C032E03D8F3471");

            entity.Property(e => e.IdCategoriaProduto).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.IdFornecedor).HasName("PK__Forneced__22E24EC694DF9F77");

            entity.Property(e => e.IdFornecedor).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__2E883C23BCBDB2E6");

            entity.Property(e => e.IdProduto).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdCategoriaProdutoNavigation).WithMany(p => p.Produtos).HasConstraintName("FK__Produto__IdCateg__6754599E");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Produtos).HasConstraintName("FK__Produto__IdForne__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
