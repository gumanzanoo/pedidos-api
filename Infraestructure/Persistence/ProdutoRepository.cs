using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;

namespace PedidosAPI.Infraestructure.Persistence;

public class ProdutoRepository : IProdutoRepository
{
    public Task<IEnumerable<Produto>> GetProdutosListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Produto> GetProdutoByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Produto> AddProdutoAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateProdutoAsync(Produto produto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProdutoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}