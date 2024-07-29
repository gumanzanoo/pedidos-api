using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;

namespace PedidosAPI.Infraestructure.Persistence;

public class PedidoRepository : IPedidoRepository
{
    public Task<IEnumerable<Pedido>> GetPedidosListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Pedido?> GetPedidoByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Pedido> AddPedidoAsync(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePedidoAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeletePedidoAsync()
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}