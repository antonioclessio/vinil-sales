using System.ComponentModel.DataAnnotations;
using VinilSales.Domain.ClienteContext.Enum;
using VinilSales.Repository.Domain.CoreContext.Base;

namespace VinilSales.Repository.Domain.ClienteContext.Entities
{
    // Para gerar extrato.
    public class Cliente_TransacaoEntity : BaseEntity
    {
        public Cliente_TransacaoEntity(int idCliente, int idPedido, decimal valorPedido, decimal valorTransacao)
        {
            this.IdCliente = idCliente;
            this.IdPedido = idPedido;
            this.ValorPedido = valorPedido;
            this.ValorTransacao = valorTransacao;
            this.TipoTransacao = (byte) TipoTransacaoExtratoEnum.Credito;
        }

        public Cliente_TransacaoEntity(int idCliente, decimal valorTransacao)
        {
            this.IdCliente = idCliente;
            this.ValorTransacao = valorTransacao;
            this.TipoTransacao = (byte)TipoTransacaoExtratoEnum.Debito;
        }

        [Key]
        public int IdClienteExtrato { get; set; }

        [Required]
        public int IdCliente { get; set; }

        // Quando o IdPedido tiver valor, é sinal de que foi realizado um crédito, caso contrário o registro do extrato equivale a um débito.
        public int? IdPedido { get; set; }

        public decimal? ValorPedido { get; set; }

        public byte TipoTransacao { get; private set; }

        [Required]
        public decimal ValorTransacao { get; set; }

        #region # Metodos
        public override bool IsValid()
        {
            if (IdPedido.HasValue && (!ValorPedido.HasValue || ValorPedido.Value == 0))
                return false;

            if (ValorTransacao <= 0) return false;

            return true;
        }
        #endregion
    }
}
