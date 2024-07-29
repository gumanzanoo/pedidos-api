using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;
using PedidosAPI.Infraestructure.Data;

namespace PedidosAPI.Infraestructure.Persistence;

public class ItemPedidoRepository : IItemPedidoRepository
{
    private readonly AppDbContext _db;

    public ItemPedidoRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ItemPedido> AddItemAsync(ItemPedido itemPedido)
    {
        _db.ItemsPedido.Add(itemPedido);
        await _db.SaveChangesAsync();
        return itemPedido;
    }

    public async Task UpdateItemAsync(ItemPedido itemPedido)
    {
        _db.ItemsPedido.Update(itemPedido);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(int id)
    {
        var itemPedido = await _db.ItemsPedido.FindAsync(id);
        if (itemPedido != null)
        {
            _db.ItemsPedido.Remove(itemPedido);
            await _db.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}