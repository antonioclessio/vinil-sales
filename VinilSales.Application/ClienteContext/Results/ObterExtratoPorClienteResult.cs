using System;
using VinilSales.Domain.ClienteContext.Enum;

namespace VinilSales.Application.ClienteContext.Results
{
    public class ObterExtratoPorClienteResult
    {
        public DateTime DataHoraCadastro { get; set; }
        public byte TipoTransacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public string TipoTransacaoDescricao
        {
            get
            {
                return Enum.GetName(typeof(TipoTransacaoExtratoEnum), TipoTransacao);
            }
        }
    }
}
