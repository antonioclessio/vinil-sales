using MediatR;
using System.Collections.Generic;
using VinilSales.Application.PedidoContext.Results;
using VinilSales.Domain.ClienteContext.Models;
using VinilSales.Domain.PedidoContext.Model;

namespace VinilSales.Application.PedidoContext.Queries
{
    public class ObterPorFiltroQuery : IRequest<IEnumerable<ObterPorFiltroResult>>
    {
        public ObterPorFiltroQuery(PedidoFiltroModel filtro)
        {
            this.Filtro = filtro;
        }

        public PedidoFiltroModel Filtro { get; set; }
    }
}
