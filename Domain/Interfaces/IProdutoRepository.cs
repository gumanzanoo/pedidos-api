using PedidosAPI.Domain.Entities;

namespace PedidosAPI.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetProdutosListAsync();
    Task<Produto> GetProdutoByIdAsync();
    Task<Produto> AddProdutoAsync();
    Task UpdateProdutoAsync(Produto produto);
    Task DeleteProdutoAsync(int id);
    Task SaveChangesAsync();
}