using GreenLife.WebAPI.DTO;
using GreenLife.WebAPI.Interfaces;
using GreenLife.WebAPI.Models;
using GreenLife.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenLife.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoController(ICategoriaProdutoRepository categoriaProdutoRepository)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de listar todas as categorias de produto
        /// </summary>
        /// <returns>A lista de categorias de produto</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoriaProdutoRepository.Listar());

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de buscar uma categoria de produto por id
        /// </summary>
        /// <param name="id">Id da categoria buscada</param>
        /// <returns>A lista de categorias de produto</returns>

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_categoriaProdutoRepository.BuscarPorId(id));

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de cadastrar uma nova categoria de produto
        /// </summary>
        /// <param name="categoriaProduto">Categoria de produto a ser cadastrada</param>
        /// <returns>Status code 201</returns>
        [HttpPost]
        public IActionResult Cadastrar(CategoriaProdutoDTO categoriaProduto)
        {
            try
            {
                var novaCategoria = new CategoriaProduto
                {
                    Titulo = categoriaProduto.Titulo!
                };

                _categoriaProdutoRepository.Cadastrar(novaCategoria);
                return StatusCode(201, categoriaProduto);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de atualizar uma categoria de produto existente
        /// </summary>
        /// <param name="id">Id da categoria de produto que vai ser atualizado</param>
        /// <param name="categoriaProduto">Novos dados da categoria</param>
        /// <returns>Status code 200 e a categoria atualizada</returns>

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, CategoriaProdutoDTO categoriaProduto)
        {
            try
            {
                var novaCategoria = new CategoriaProduto
                {
                    Titulo = categoriaProduto.Titulo!
                };

                _categoriaProdutoRepository.Atualizar(id, novaCategoria);
                return Ok(_categoriaProdutoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de deletar uma categoria de produto existente
        /// </summary>
        /// <param name="id">Da categoria buscada</param>
        /// <returns>Status code 204</returns>

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _categoriaProdutoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
