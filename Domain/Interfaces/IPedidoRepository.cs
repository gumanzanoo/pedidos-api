using PedidosAPI.Domain.Entities;

namespace PedidosAPI.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> GetPedidosListAsync(bool? status);
    Task<Pedido?> GetPedidoByIdAsync(int id);
    Task<Pedido> AddPedidoAsync(Pedido pedido);
    Task UpdatePedidoAsync(Pedido pedido);
    Task DeletePedidoAsync(int id);
    Task SaveChangesAsync();
}