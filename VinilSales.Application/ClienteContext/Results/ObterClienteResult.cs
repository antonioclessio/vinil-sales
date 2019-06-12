using System;
using VinilSales.Domain.CoreContext.ValueObjects;

namespace VinilSales.Application.ClienteContext.Results
{
    public class ObterClienteResult
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public short Status { get; set; }
        public CPF CPF { get; set; }
    }
}
