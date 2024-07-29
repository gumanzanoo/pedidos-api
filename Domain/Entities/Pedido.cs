namespace PedidosAPI.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public ICollection<ItemPedido> ItemsPedido { get; set; } = new List<ItemPedido>();
    public decimal ValorTotal { get; set; }
    public bool Fechado { get; set; }
    public DateTime DataPedido { get; set; } = DateTime.UtcNow;

    public void CalcularValorTotal()
    {
        ValorTotal = ItemsPedido.Sum(item => item.Produto.Preco * item.QtdProduto);
    }
}