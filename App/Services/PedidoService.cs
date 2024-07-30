using PedidosAPI.App.Interface;
using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;

namespace PedidosAPI.App.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoRepository _produtoRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<(IEnumerable<Pedido> Pedidos, int TotalCount)> GetPedidosListAsync(
        bool? status, int pageNumber, int pageSize)
    {
        return await _pedidoRepository.GetPedidosListAsync(status, pageNumber, pageSize);
    }

    public async Task<Pedido?> GetPedidoByIdAsync(int id)
    {
        var pedido = await _pedidoRepository.GetPedidoByIdAsync(id);
        if (pedido == null)
        {
            throw new KeyNotFoundException($"Pedido ID {id} não encontrado.");
        }
        return pedido;
    }

    public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
    {
        foreach (var item in pedido.ItemsPedido)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(item.ProdutoId);
            if (produto == null)
            {
                throw new InvalidOperationException($"O produto de ID {item.ProdutoId} não existe.");
            }

            item.Produto = produto;
        }
        
        return await _pedidoRepository.AddPedidoAsync(pedido);
    }

    public async Task AddProdutoAsync(int pedidoId, int produtoId, int quantidade)
    {
        var pedido = await _pedidoRepository.GetPedidoByIdAsync(pedidoId);
        var produto = await _produtoRepository.GetProdutoByIdAsync(produtoId);

        if (pedido == null)
            throw new InvalidOperationException($"Nenhum pedido com ID {pedidoId} encontrado.");
        if (pedido.Fechado)
            throw new InvalidOperationException("Não é possível adicionar produtos a um pedido fechado.");
        if (produto == null)
            throw new InvalidOperationException($"Nenhum produto com ID {produtoId} encontrado.");

        var item = new ItemPedido
        {
            PedidoId = pedido.Id,
            ProdutoId = produto.Id,
            QtdProduto = quantidade,
            Produto = produto,
        };

        pedido.ItemsPedido.Add(item);
        pedido.CalcularValorTotal();

        await _pedidoRepository.SaveChangesAsync();
    }

    public async Task RmProdutoAsync(int pedidoId, int produtoId)
    {
        var pedido = await _pedidoRepository.GetPedidoByIdAsync(pedidoId);

        if (pedido == null)
            throw new InvalidOperationException($"Nenhum pedido com ID {pedidoId} encontrado.");
        if (pedido.Fechado)
            throw new InvalidOperationException("Não é possível adicionar produtos a um pedido fechado.");

        var itemPedido = pedido.ItemsPedido.FirstOrDefault(i => i.ProdutoId == produtoId);
        if (itemPedido != null)
        {
            pedido.ItemsPedido.Remove(itemPedido);
            pedido.CalcularValorTotal();
            await _pedidoRepository.UpdatePedidoAsync(pedido);
        }
    }

    public async Task FecharPedidoAsync(int pedidoId)
    {
        var pedido = await _pedidoRepository.GetPedidoByIdAsync(pedidoId);
        if (pedido == null)
            throw new InvalidOperationException($"Nenhum pedido com ID {pedidoId} encontrado.");
        if (!pedido.ItemsPedido.Any())
            throw new InvalidOperationException("Não é possível fechar um pedido vazio.");

        pedido.Fechado = true;
        await _pedidoRepository.UpdatePedidoAsync(pedido);
    }

    public async Task UpdatePedidoAsync(Pedido pedido)
    {
        await _pedidoRepository.UpdatePedidoAsync(pedido);
    }

    public async Task DeletePedidoAsync(int id)
    {
        await _pedidoRepository.DeletePedidoAsync(id);
    }
}