using GreenLife.WebAPI.BdContextGreenLife;
using GreenLife.WebAPI.Interfaces;
using GreenLife.WebAPI.Models;

namespace GreenLife.WebAPI.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly GreenLifeContext _context;

        public FornecedorRepository(GreenLifeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza um fornecedor
        /// </summary>
        /// <param name="id">Id do fornecedor buscado</param>
        /// <param name="fornecedor">Dados do fornecedor</param>
        public void Atualizar(Guid id, Fornecedor fornecedor)
        {
            var fornecedorBuscado = _context.Fornecedors.Find(id);
            if (fornecedorBuscado != null)
            {
                fornecedorBuscado.NomeFantasia = string.IsNullOrEmpty(fornecedor.NomeFantasia) ? fornecedorBuscado.NomeFantasia : fornecedor.NomeFantasia;
                fornecedorBuscado.Cnpj = string.IsNullOrEmpty(fornecedor.Cnpj) ? fornecedorBuscado.Cnpj : fornecedor.Cnpj;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um fornecedor por Id
        /// </summary>
        /// <param name="id">Id do fornecedor buscado</param>
        /// <returns>Retorna o fornecedor buscado</returns>
        public Fornecedor BuscarPorId(Guid id)
        {
            return _context.Fornecedors.Find(id)!;
        }

        /// <summary>
        /// Cadastra um fornecedor
        /// </summary>
        /// <param name="fornecedor">Dados do fornecedor</param>
        public void Cadastrar(Fornecedor fornecedor)
        {
            _context.Fornecedors.Add(fornecedor);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta um fornecedor 
        /// </summary>
        /// <param name="id">Id do fornecedor que será deletado</param>
        public void Deletar(Guid id)
        {
            var fornecedorBuscado = _context.Fornecedors.Find(id);
            if(fornecedorBuscado != null)
            {
              _context.Fornecedors.Remove(fornecedorBuscado);
              _context.SaveChanges();
            }
        }
        /// <summary>
        /// Lista todos os fornecedores
        /// </summary>
        /// <returns>Retorna lista de fornecedores</returns>
        public List<Fornecedor> Listar()
        {
            return _context.Fornecedors.OrderBy(e => e.NomeFantasia).ToList();
        }
    }
}
