using GreenLife.WebAPI.BdContextGreenLife;
using GreenLife.WebAPI.Interfaces;
using GreenLife.WebAPI.Models;

namespace GreenLife.WebAPI.Repositories
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        private readonly GreenLifeContext _context;

        public CategoriaProdutoRepository (GreenLifeContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Atualiza uma categoria utilizando Id
        /// </summary>
        /// <param name="id">id de categoria a ser atualizado</param>
        /// <param name="categoriaProduto">Novos dados da categoriaProduto</param>
        public void Atualizar(Guid id, CategoriaProduto categoriaProduto)
        {
            var categoriaBuscada = _context.CategoriaProdutos.Find(id);

            if (categoriaBuscada != null)
            {
                categoriaBuscada.Titulo = string.IsNullOrEmpty(categoriaProduto.Titulo) ? categoriaBuscada.Titulo : categoriaProduto.Titulo;

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca uma categoriaProduto por id
        /// </summary>
        /// <param name="id">Id da categoria de produto a ser buscado</param>
        /// <returns>Objeto CategoriaProduto </returns>
        public CategoriaProduto BuscarPorId(Guid id)
        {
            return _context.CategoriaProdutos.Find(id)!;
        }

        public void Cadastrar(CategoriaProduto categoriaProduto)
        {
            _context.CategoriaProdutos.Add(categoriaProduto);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
        
            var categoriaBuscada = _context.CategoriaProdutos.Find(id);

            if (categoriaBuscada != null)
            {
                _context.CategoriaProdutos.Remove(categoriaBuscada);
                _context.SaveChanges();
            }
        }
        

        public List<CategoriaProduto> Listar()
        {
            return _context.CategoriaProdutos.OrderBy(e => e.Titulo).ToList();
        }
    }
}
