using MediatR;
using VinilSales.Application.ClienteContext.Results;
using VinilSales.Domain.CoreContext.ValueObjects;

namespace VinilSales.Application.ClienteContext.Queries
{
    public class ObterClienteQuery : IRequest<ObterClienteResult>
    {
        public ObterClienteQuery(int? id)
        {
            this.Id = id;
        }

        public ObterClienteQuery(CPF cpf)
        {
            this.CPF = cpf;
        }

        public int? Id { get; set; }
        public CPF? CPF { get; set; }
    }
}
