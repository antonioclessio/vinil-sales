using MediatR;
using VinilSales.Domain.CoreContext.ValueObjects;

namespace VinilSales.Application.ClienteContext.Commands
{
    public class SalvarClienteCommand : IRequest<bool>
    {
        public SalvarClienteCommand(int idCliente, string nome, CPF cpf)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.CPF = cpf;
        }

        public SalvarClienteCommand(string nome, CPF cpf)
        {
            this.Nome = nome;
            this.CPF = cpf;
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public CPF CPF { get; set; }
    }
}
