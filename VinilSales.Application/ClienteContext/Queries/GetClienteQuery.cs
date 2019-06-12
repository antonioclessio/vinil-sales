using MediatR;
using VinilSales.Application.ClienteContext.Results;
using VinilSales.Domain.CoreContext.ValueObjects;

namespace VinilSales.Application.ClienteContext.Queries
{
    public class GetClienteQuery : IRequest<GetClienteResult>
    {
        public GetClienteQuery(int? id)
        {
            this.Id = id;
        }

        public GetClienteQuery(CPF cpf)
        {
            this.CPF = cpf;
        }

        public int? Id { get; set; }
        public CPF? CPF { get; set; }
    }
}
