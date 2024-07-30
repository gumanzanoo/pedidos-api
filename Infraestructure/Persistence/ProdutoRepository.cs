using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;
using PedidosAPI.Infraestructure.Data;

namespace PedidosAPI.Infraestructure.Persistence;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _db;

    public ProdutoRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<(IEnumerable<Produto> Produtos, int TotalCount)> GetProdutosListAsync(
        int pageNumber, int pageSize)
    {
        var queryProdutos = _db.Produtos;
        return (await queryProdutos.ToListAsync(), await queryProdutos.CountAsync());
    }

    public async Task<Produto?> GetProdutoByIdAsync(int id)
    {
        return await _db.Produtos.FindAsync(id);
    }

    public async Task<Produto> AddProdutoAsync(Produto produto)
    {
        _db.Produtos.Add(produto);
        await _db.SaveChangesAsync();
        return produto;
    }

    public async Task UpdateProdutoAsync(Produto produto)
    {
        _db.Produtos.Update(produto);
        await SaveChangesAsync();
    }

    public async Task DeleteProdutoAsync(int id)
    {
        var produto = await _db.Produtos.FindAsync(id);
        if (produto != null)
        {
            _db.Produtos.Remove(produto);
            await SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}