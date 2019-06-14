using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace VinilSales.Application.PedidoContext.Results
{
    public class ObterPedidoResult
    {
        public int IdCliente { get; set; }
        public int IdTabelaCashback { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal ValorCashback { get { return Itens.Sum(a => a.ValorCashback); } }

        public List<ObterPedido_ItemResult> Itens { get; set; } = new List<ObterPedido_ItemResult>();
    }
}
