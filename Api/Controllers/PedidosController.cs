using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Api.DTOs;
using PedidosAPI.Domain.Entities;
using PedidosAPI.App.Interface;

namespace PedidosAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos([FromQuery] bool? status)
        {
            try
            {
                var pedidos = await _pedidoService.GetPedidosListAsync(status);
                return Ok(pedidos);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);
                return Ok(pedido);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CreatePedido(PedidoDTO pedidoDto)
        {
            var pedido = new Pedido
            {
                NomeCliente = pedidoDto.NomeCliente,
                ItemsPedido = new List<ItemPedido>(),
            };

            foreach (var itemDto in pedidoDto.ItemsPedido)
            {
                var item = new ItemPedido
                {
                    ProdutoId = itemDto.ProdutoId,
                    QtdProduto = itemDto.QtdProduto,
                };
                pedido.ItemsPedido.Add(item);
            }

            try
            {
                var createdPedido = await _pedidoService.CreatePedidoAsync(pedido);
                return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.Id }, createdPedido);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("{pedidoId}/produtos/{produtoId}")]
        public async Task<IActionResult> AddProdutoToPedido(int pedidoId, int produtoId, [FromBody] int quantidade)
        {
            try
            {
                await _pedidoService.AddProdutoAsync(pedidoId, produtoId, quantidade);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{pedidoId}/produtos/{produtoId}")]
        public async Task<IActionResult> RemoveProdutoFromPedido(int pedidoId, int produtoId)
        {
            try
            {
                await _pedidoService.RmProdutoAsync(pedidoId, produtoId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });

            }
        }

        [HttpPost("{pedidoId}/close")]
        public async Task<IActionResult> ClosePedido(int pedidoId)
        {
            try
            {
                await _pedidoService.FecharPedidoAsync(pedidoId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                await _pedidoService.DeletePedidoAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        } 
    }
}