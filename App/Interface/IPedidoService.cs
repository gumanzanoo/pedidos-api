using PedidosAPI.Domain.Entities;

namespace PedidosAPI.App.Interface;

public interface IPedidoService
{
    Task<IEnumerable<Pedido>> GetPedidosListAsync();
    Task<Pedido?> GetPedidoByIdAsync(int id);
    Task<Pedido> CreatePedidoAsync(Pedido pedido);
    Task AddProdutoAsync(int pedidoId, int produtoId, int quantidade);
    Task RmProdutoAsync(int pedidoId, int produtoId);
    Task FecharPedidoAsync(int pedidoId);
    Task UpdatePedidoAsync(Pedido pedido);
    Task DeletePedidoAsync(int id);
}