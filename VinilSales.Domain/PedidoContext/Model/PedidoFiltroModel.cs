using System;
using VinilSales.Domain.ClienteContext.Models;

namespace VinilSales.Domain.PedidoContext.Model
{
    public class PedidoFiltroModel
    {
        public int? IdCliente { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public PaginacaoModel Paginacao { get; set; } = new PaginacaoModel();
    }
}
