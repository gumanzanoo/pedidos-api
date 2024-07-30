using PedidosAPI.Domain.Entities;

namespace PedidosAPI.App.Interface;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> GetProdutosListAsync();
    Task<Produto?> GetProdutoByIdAsync(int id);
    Task<Produto> CreateProdutoAsync(Produto produto);
    Task UpdateProdutoAsync(Produto produto);
    Task DeleteProdutoAsync(int id);
}