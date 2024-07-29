using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;

namespace PedidosAPI.Infraestructure.Persistence;

public class ItemPedidoRepository : IItemPedidoRepository
{
    public Task<ItemPedido> AddItemAsync(ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }

    public Task UpdateItemAsync(ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }

    public Task DeleteItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}