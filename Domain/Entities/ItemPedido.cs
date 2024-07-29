namespace PedidosAPI.Domain.Entities;

public class ItemPedido
{
    public int Id { get; set; }
    
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = new Pedido();
    
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = new Produto();
    
    public int QtdProduto { get; set; }
}