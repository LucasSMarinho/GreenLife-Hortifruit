using GreenLife.WebAPI.DTO;
using GreenLife.WebAPI.Interfaces;
using GreenLife.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenLife.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de listar todos os produtos
        /// </summary>
        /// <returns>A lista de produto</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de buscar um produto por id
        /// </summary>
        /// <param name="id">Id produto buscado</param>
        /// <returns>A lista de produto</returns>

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_produtoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de cadastrar um novo produto, recebendo os dados do produto via form-data, incluindo a imagem do produto
        /// </summary>
        /// <param name="produto">Produto a ser cadastrado</param>
        /// <returns>Status code 201</returns>

        [HttpPost]

        public async Task<IActionResult> Post([FromForm] ProdutoDTO produto)
        {

            var novoProduto = new Produto();

            if (produto.Imagem != null && produto.Imagem.Length > 0)
            {
                var extensao = Path.GetExtension(produto.Imagem.FileName);

                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                var pastaRelativa = "wwwroot/imagens";
                var caminhaPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                //Para garantir que a pasta exista
                if (!Directory.Exists(caminhaPasta))
                    Directory.CreateDirectory(caminhaPasta);

                var caminhoCompleto = Path.Combine(caminhaPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await produto.Imagem.CopyToAsync(stream);
                }

                novoProduto.Imagem = nomeArquivo;

            }

            novoProduto.Nome = produto.Nome!;
            novoProduto.Preco = produto.Preco!;
            novoProduto.IdCategoriaProduto = produto.IdCategoriaProduto;
            novoProduto.IdFornecedor = produto.IdFornecedor;

            try
            {
                _produtoRepository.Cadastrar(novoProduto);
                return StatusCode(201, novoProduto);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de atualizar um produto
        /// </summary>
        /// <param name="id">Id do produto que vai ser atualizado</param>
        /// <param name="produtoAtualizado">Novos dados do produto</param>
        /// <returns>Status code 200 e produto atualizado</returns>

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(Guid id, [FromForm] produtoDTOAtualizar produtoAtualizado)
        {

            var produtoBuscado = _produtoRepository.BuscarPorId(id);
            if (produtoBuscado == null)
                return NotFound("Produto não encontrado");

            if (produtoAtualizado.Imagem != null && produtoAtualizado.Imagem.Length > 0)
            {
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                //Deleta arquivo antigo
                if (!string.IsNullOrEmpty(produtoBuscado.Imagem))
                {
                    var caminhoAntigo = Path.Combine(caminhoPasta, produtoBuscado.Imagem);
                    if (System.IO.File.Exists(caminhoAntigo))
                        System.IO.File.Delete(caminhoAntigo);
                }

                var extensao = Path.GetExtension(produtoAtualizado.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await produtoAtualizado.Imagem.CopyToAsync(stream);
                }

                produtoBuscado.Imagem = nomeArquivo;
            }

            if (!string.IsNullOrEmpty(produtoAtualizado.Nome))
                produtoBuscado.Nome = produtoAtualizado.Nome;


            produtoBuscado.IdFornecedor = (produtoAtualizado.IdFornecedor == null) ? produtoBuscado.IdFornecedor : produtoAtualizado.IdFornecedor;
            produtoBuscado.IdCategoriaProduto = (produtoAtualizado.IdCategoriaProduto == null) ? produtoBuscado.IdCategoriaProduto : produtoAtualizado.IdCategoriaProduto;
            produtoBuscado.Preco = (produtoAtualizado.Preco <= 0) ? produtoBuscado.Preco : produtoAtualizado.Preco;


            try
            {
                _produtoRepository.Atualizar(id, produtoBuscado);
                return Ok(_produtoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamada ao método de deletar um produto por id. 
        /// </summary>
        /// <param name="id">Do produto buscado</param>
        /// <returns>Status code 204</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            var produtoBuscado = _produtoRepository.BuscarPorId(id);

            if (produtoBuscado == null)
                return NotFound("Produto não encontrado");

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            //Deleta o arquivo

            if (!string.IsNullOrEmpty(produtoBuscado.Imagem))
            {
                var caminho = Path.Combine(caminhoPasta, produtoBuscado.Imagem);

                if (System.IO.File.Exists(caminho))
                    System.IO.File.Delete(caminho);
            }

            try
            {
                _produtoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
