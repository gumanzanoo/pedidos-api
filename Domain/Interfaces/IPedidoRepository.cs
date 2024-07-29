using PedidosAPI.Domain.Entities;

namespace PedidosAPI.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> GetPedidosListAsync();
    Task<Pedido?> GetPedidoByIdAsync(int id);
    Task<Pedido> AddPedidoAsync(Pedido pedido);
    Task UpdatePedidoAsync();
    Task DeletePedidoAsync();
    Task SaveChangesAsync();
}