using System;
using System.Collections.Generic;
using System.Text;
using VinilSales.Domain.CoreContext.ValueObjects;

namespace VinilSales.Application.ClienteContext.Results
{
    public class GetClienteResult
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public short Status { get; set; }
        public CPF CPF { get; set; }
    }
}
