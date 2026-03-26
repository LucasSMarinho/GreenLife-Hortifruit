using GreenLife.WebAPI.Models;

namespace GreenLife.WebAPI.Interfaces
{
    public interface ICategoriaProdutoRepository
    {
        List<CategoriaProduto> Listar();
        public CategoriaProduto BuscarPorId(Guid Id);
        public void Cadastrar(CategoriaProduto categoriaProduto);
        public void Atualizar(Guid id, CategoriaProduto categoriaProduto);
        public void Deletar(Guid id);
    }
}
