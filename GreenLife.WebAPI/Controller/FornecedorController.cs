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
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController (IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de listar todos os fornecedores
        /// </summary>
        /// <returns>A lista de fornecedores</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_fornecedorRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de buscar um fornecedor por id
        /// </summary>
        /// <param name="id">Id do fornecedor</param>
        /// <returns>A lista de fornecedor</returns>

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_fornecedorRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de cadastrar um novo fornecedor
        /// </summary>
        /// <param name="fornecedor">Dados do fornecedor</param>
        /// <returns>Status code 201</returns>

        [HttpPost]
        public IActionResult Cadastrar(FornecedorDTO fornecedor)
        {
            try
            {
                var novoFornecedor = new Fornecedor
                {
                    Cnpj = fornecedor.Cnpj!,
                    NomeFantasia = fornecedor.NomeFantasia!
                };

                _fornecedorRepository.Cadastrar(novoFornecedor);
                return StatusCode(201, novoFornecedor);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de atualizar um fornecedor existente
        /// </summary>
        /// <param name="id">Id do fornecedor que vai ser atualizado</param>
        /// <param name="fornecedor">Novos dados do fornecedor </param>
        /// <returns>Status code 200 e a categoria atualizada</returns>

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, FornecedorDTO fornecedor)
        {
            try
            {

                var novoFornecedor = new Fornecedor
                {
                    Cnpj = fornecedor.Cnpj!,
                    NomeFantasia = fornecedor.NomeFantasia!
                };

                _fornecedorRepository.Atualizar(id, novoFornecedor);
                return Ok(novoFornecedor);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de deletar um fornecedor existente
        /// </summary>
        /// <param name="id">Do fornecedor</param>
        /// <returns>Status code 204</returns>

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _fornecedorRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
