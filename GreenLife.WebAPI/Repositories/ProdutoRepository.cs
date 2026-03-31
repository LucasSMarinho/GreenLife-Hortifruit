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

    public Produto BuscarPorId(Guid Id)
    {
        return _context.Produtos.Find(Id)!;
    }

    public void Cadastrar(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var produtoBuscado = _context.Produtos.Find(id);

        if (produtoBuscado != null)
        {
            _context.Produtos.Remove(produtoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Produto> Listar()
    {
        return _context.Produtos.OrderBy(e => e.Nome).ToList();
    }
}
