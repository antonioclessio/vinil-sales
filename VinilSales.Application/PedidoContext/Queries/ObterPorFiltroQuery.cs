using MediatR;
using System.Collections.Generic;
using VinilSales.Application.PedidoContext.Results;

namespace VinilSales.Application.PedidoContext.Queries
{
    public class ObterPorFiltroQuery : IRequest<IEnumerable<ObterPorFiltroResult>>
    {
        public ObterPorFiltroQuery(int idCliente, int pagina, int totalPorPagina)
        {
            this.IdCliente = idCliente;
            this.Pagina = pagina;
            this.TotalPorPagina = totalPorPagina;
        }

        public int IdCliente { get; set; }
        public int Pagina { get; set; }
        public int TotalPorPagina { get; set; }
    }
}
