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

        [HttpPut]
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

        [HttpDelete]
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
