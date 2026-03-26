using GreenLife.WebAPI.Models;

namespace GreenLife.WebAPI.Interfaces
{
    public interface IFornecedorRepository
    {
        List<Fornecedor> Listar();
        public Fornecedor BuscarPorId(Guid Id);
        public void Cadastrar(Fornecedor fornecedor);
        public void Atualizar(Guid id, Fornecedor fornecedor);
        public void Deletar(Guid id);
    }
}
