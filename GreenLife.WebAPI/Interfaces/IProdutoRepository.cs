using GreenLife.WebAPI.Models;

namespace GreenLife.WebAPI.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();
        public Produto BuscarPorId(Guid Id);
        public void Cadastrar();
        public void Atualizar(Guid id, Produto produto);
        public void Deletar(Guid id);
    }
}
