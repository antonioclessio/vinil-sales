using MediatR;
using System.Collections.Generic;
using VinilSales.Application.ClienteContext.Results;

namespace VinilSales.Application.ClienteContext.Queries
{
    public class ObterExtratoPorClienteQuery : IRequest<IEnumerable<ObterExtratoPorClienteResult>>
    {
        public ObterExtratoPorClienteQuery(int idCliente)
        {
            this.IdCliente = idCliente;
        }

        public int IdCliente { get; set; }
    }
}
