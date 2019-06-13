using System.Collections.Generic;

namespace VinilSales.WebAPI.Models.Pedido
{
    public class SalvarPedido_ItemModel
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
