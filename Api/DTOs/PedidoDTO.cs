namespace PedidosAPI.Api.DTOs
{
    public class PedidoDTO
    {
        public string NomeCliente { get; set; } = string.Empty;
        public List<ItemPedidoDTO> ItemsPedido { get; set; } = new List<ItemPedidoDTO>();
    }
}