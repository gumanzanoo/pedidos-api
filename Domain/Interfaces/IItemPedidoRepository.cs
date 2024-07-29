using PedidosAPI.Domain.Entities;

namespace PedidosAPI.Domain.Interfaces;

public interface IItemPedidoRepository
{
    Task<ItemPedido> AddItemAsync(ItemPedido itemPedido);
    Task UpdateItemAsync(ItemPedido itemPedido);
    Task DeleteItemAsync(int id);
    Task SaveChangesAsync();
}