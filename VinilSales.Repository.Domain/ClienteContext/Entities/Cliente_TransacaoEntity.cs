using System;
using System.ComponentModel.DataAnnotations;
using VinilSales.Domain.ClienteContext.Enum;
using VinilSales.Repository.Domain.CoreContext.Entities;

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
        public override void Validacao()
        {
            if (IdPedido.HasValue && (!ValorPedido.HasValue || ValorPedido.Value == 0)) Mensagens.Add("O pedido relacionado à transação não tem um valor válido.");
            if (ValorTransacao <= 0) Mensagens.Add("O valor a ser transacionado no cashback é inválido");
            if (Enum.TryParse<TipoTransacaoExtratoEnum>(TipoTransacao.ToString(), out _)) Mensagens.Add("O tipo de transação informado é inválido.");
        }
        #endregion
    }
}
