using System.Collections.Generic;

namespace VinilSales.WebAPI.Models.Pedido
{
    public class SalvarPedidoModel
    {
        public int IdCliente { get; set; }

        public List<SalvarPedido_ItemModel> Itens { get; set; } = new List<SalvarPedido_ItemModel>();
    }
}
