using Microsoft.AspNetCore.Mvc;
using PedidosAPI.App.Interface;
using PedidosAPI.Domain.Entities;

namespace PedidosAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _produtoService.GetProdutosListAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto(Produto produto)
        {
            var createdProduto = await _produtoService.CreateProdutoAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = createdProduto.Id }, createdProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            await _produtoService.UpdateProdutoAsync(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            await _produtoService.DeleteProdutoAsync(id);
            return NoContent();
        }
    }
}