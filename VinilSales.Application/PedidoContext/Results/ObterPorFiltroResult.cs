using System.Collections.Generic;
using VinilSales.Repository.Domain.PedidoContext.Entities;

namespace VinilSales.Application.PedidoContext.Results
{
    public class ObterPorFiltroResult
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }

        public int IdTabelaCashback { get; set; }

        public decimal ValorPedido { get; set; }
    }
}
