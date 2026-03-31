using GreenLife.WebAPI.BdContextGreenLife;
using GreenLife.WebAPI.Interfaces;
using GreenLife.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenLife.WebAPI.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly GreenLifeContext _context;

    public ProdutoRepository(GreenLifeContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um produto
    /// </summary>
    /// <param name="id">Id do produto que será atualizado</param>
    /// <param name="produtoAtualizado">Novos dados do produto</param>
    public void Atualizar(Guid id, Produto produtoAtualizado)
    {
        var produtoBuscado = _context.Produtos.Find(id);

        if (produtoBuscado != null)
        {
            produtoBuscado.Nome = produtoAtualizado.Nome;
            produtoBuscado.Imagem = produtoAtualizado.Imagem;
            produtoBuscado.Preco = produtoAtualizado.Preco;
            produtoBuscado.IdFornecedor = produtoAtualizado.IdFornecedor;
            produtoBuscado.IdCategoriaProduto = produtoAtualizado.IdCategoriaProduto;
            _context.Produtos.Update(produtoBuscado);
        }
            _context.SaveChanges();
    }

    /// <summary>
    /// Busca um produto pelo seu id
    /// </summary>
    /// <param name="Id">Id do produto buscado</param>
    /// <returns>Retorna o produto buscado</returns>
    public Produto BuscarPorId(Guid Id)
    {
        return _context.Produtos.Find(Id)!;
    }

    /// <summary>
    /// Cadastra um produto
    /// </summary>
    /// <param name="produto">Dados do produto</param>
    public void Cadastrar(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um produto
    /// </summary>
    /// <param name="id">Id do produto que será deletado</param>
    public void Deletar(Guid id)
    {
        var produtoBuscado = _context.Produtos.Find(id);

        if (produtoBuscado != null)
        {
            _context.Produtos.Remove(produtoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Lista todos os produtos
    /// </summary>
    /// <returns>Retorna lita de produtos</returns>
    public List<Produto> Listar()
    {
        return _context.Produtos.OrderBy(e => e.Nome).ToList();
    }
}
