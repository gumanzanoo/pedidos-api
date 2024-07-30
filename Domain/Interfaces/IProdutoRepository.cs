using PedidosAPI.Domain.Entities;

namespace PedidosAPI.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<(IEnumerable<Produto> Produtos, int TotalCount)> GetProdutosListAsync(int pageNumber, int pageSize);
    Task<Produto?> GetProdutoByIdAsync(int id);
    Task<Produto> AddProdutoAsync(Produto produto);
    Task UpdateProdutoAsync(Produto produto);
    Task DeleteProdutoAsync(int id);
    Task SaveChangesAsync();
}