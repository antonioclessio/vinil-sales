using MediatR;

namespace VinilSales.Application.ClienteContext.Commands
{
    public class RegistrarTransacaoCashbackCommand : IRequest<bool>
    {
        public RegistrarTransacaoCashbackCommand(int idCliente, int idPedido, decimal valorPedido, decimal percentualCashback, decimal valorTransacao)
        {
            this.IdCliente = idCliente;
            this.IdPedido = idPedido;
            this.ValorPedido = valorPedido;
            this.PercentualCashback = percentualCashback;
            this.ValorTransacao = valorTransacao;
        }

        public RegistrarTransacaoCashbackCommand(int idCliente, decimal valorTransacao)
        {
            this.IdCliente = idCliente;
            this.ValorTransacao = valorTransacao;
        }

        public int IdClienteExtrato { get; set; }

        public int IdCliente { get; set; }

        public int? IdPedido { get; set; }

        public decimal? ValorPedido { get; set; }

        public decimal? PercentualCashback { get; set; }

        public decimal ValorTransacao { get; set; }
    }
}
