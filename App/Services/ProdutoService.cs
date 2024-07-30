using PedidosAPI.App.Interface;
using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;

namespace PedidosAPI.App.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<Produto>> GetProdutosListAsync()
    {
        return await _produtoRepository.GetProdutosListAsync();
    }

    public async Task<Produto?> GetProdutoByIdAsync(int id)
    {
        var produto = await _produtoRepository.GetProdutoByIdAsync(id);
        if (produto == null)
        {
            throw new KeyNotFoundException($"produto ID {id} não encontrado.");
        }

        return produto;
    }

    public async Task<Produto> CreateProdutoAsync(Produto produto)
    {
        return await _produtoRepository.AddProdutoAsync(produto);
    }

    public async Task UpdateProdutoAsync(Produto produto)
    {
        await _produtoRepository.UpdateProdutoAsync(produto);
    }

    public async Task DeleteProdutoAsync(int id)
    {
        await _produtoRepository.DeleteProdutoAsync(id);
    }
}