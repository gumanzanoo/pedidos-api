using PedidosAPI.Domain.Entities;

namespace PedidosAPI.App.Interface;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> GetProdutosListAsync();
    Task<Produto?> GetByIdAsync(int id);
    Task<Produto> CreateAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(int id);
}