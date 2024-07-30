using Moq;
using PedidosAPI.App.Services;
using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Interfaces;
using Xunit;

namespace PedidosAPI.Tests.Unit;

public class PedidoServiceTests
{
    private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
    private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
    private readonly PedidoService _pedidoService;

    public PedidoServiceTests()
    {
        _pedidoRepositoryMock = new Mock<IPedidoRepository>();
        _produtoRepositoryMock = new Mock<IProdutoRepository>();
        _pedidoService = new PedidoService(
            _pedidoRepositoryMock.Object,
            _produtoRepositoryMock.Object);
    }

    [Fact]
    public async Task CreatePedidoAsync_ShouldReturnCreatedPedido()
    {
        var pedido = new Pedido
        {
            NomeCliente = "Cleiton",
            ItemsPedido = new List<ItemPedido>()
        };

        _pedidoRepositoryMock.Setup(repo => repo.AddPedidoAsync(It.IsAny<Pedido>()))
            .ReturnsAsync(pedido);

        var result = await _pedidoService.CreatePedidoAsync(pedido);
            
        Assert.Equal(pedido, result);
        _pedidoRepositoryMock.Verify(repo => repo.AddPedidoAsync(pedido), Times.Once);
    }

    [Fact]
    public async Task AddProdutoToPedidoAsync_ShouldThrowException_WhenPedidoIsClosed()
    {
        var pedido = new Pedido { Id = 1, Fechado = true };
        var produto = new Produto { Id = 1 };

        _pedidoRepositoryMock.Setup(repo => repo.GetPedidoByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(pedido);
        _produtoRepositoryMock.Setup(repo => repo.GetProdutoByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(produto);

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _pedidoService.AddProdutoAsync(pedido.Id, produto.Id, 1));
        Assert.Equal("Não é possível adicionar produtos a um pedido fechado.", ex.Message);
    }
}