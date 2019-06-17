using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinilSales.Repository.Domain.CoreContext.Entities;

namespace VinilSales.Repository.Domain.PedidoContext.Entities
{
    public class Pedido_ItemEntity : BaseEntity
    {
        [Key]
        public int PedidoItem { get; set; }

        [Required]
        public int IdPedido { get; set; }

        [Required]
        public int IdProduto { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal PercentualCashback { get; set; }

        [Required]
        public decimal ValorCashback { get { return ValorUnitario * (PercentualCashback / 100); } }

        #region # Foreign Key
        [ForeignKey("IdPedido")]
        public virtual PedidoEntity Pedido { get; set; }
        #endregion

        #region # Metodos
        public override void Validacao()
        {
            if (Quantidade == 0) Mensagens.Add("A quantidade do pedido deve ser maior que zero");
            if (IdPedido == 0) Mensagens.Add("O pedido é inválido");
            if (IdProduto == 0) Mensagens.Add("O produto é inválido");
        }
        #endregion
    }
}
