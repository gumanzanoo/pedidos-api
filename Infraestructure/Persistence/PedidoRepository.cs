using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;
using PedidosAPI.Infraestructure.Data;

namespace PedidosAPI.Infraestructure.Persistence;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _db;

    public PedidoRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Pedido>> GetPedidosListAsync(bool? status)
    {
        var queryPedidos = _db.Pedidos.AsQueryable();
        if (status.HasValue)
        {
            queryPedidos = queryPedidos.Where(p => p.Fechado == status);
        }
        return await queryPedidos
            .Include(p => p.ItemsPedido)
            .ThenInclude(i => i.Produto)
            .ToListAsync();
    }

    public async Task<Pedido?> GetPedidoByIdAsync(int id)
    {
        return await _db.Pedidos
            .Include(p => p.ItemsPedido)
            .ThenInclude(i => i.Produto)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pedido> AddPedidoAsync(Pedido pedido)
    {
        _db.Pedidos.Add(pedido);
        await _db.SaveChangesAsync();
        return pedido;
    }

    public async Task UpdatePedidoAsync(Pedido pedido)
    {
        _db.Pedidos.Update(pedido);
        await _db.SaveChangesAsync();
    }

    public async Task DeletePedidoAsync(int id)
    {
        var pedido = await _db.Pedidos.FindAsync(id);
        if (pedido != null)
        {
            _db.Pedidos.Remove(pedido);
            await _db.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}