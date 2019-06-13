using System;
using VinilSales.Domain.ClienteContext.Enum;

namespace VinilSales.Application.ClienteContext.Results
{
    public class ObterExtratoPorClienteResult
    {
        public DateTime DataHoraTransacao { get; set; }
        public byte TipoTransacao { get; set; }
        public TipoTransacaoExtratoEnum TipoTransacaoEnum { get; set; }
        public decimal ValorTransacao { get; set; }
        public decimal PercentualCashback { get; set; }
    }
}
