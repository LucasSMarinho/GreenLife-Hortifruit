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
