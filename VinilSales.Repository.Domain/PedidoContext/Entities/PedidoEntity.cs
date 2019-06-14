using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.CoreContext.Base;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;
using VinilSales.Domain.PedidoContext.Enum;

namespace VinilSales.Repository.Domain.PedidoContext.Entities
{
    public class PedidoEntity : BaseEntity
    {
        #region # Propriedades
        [Key]
        public int IdPedido { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdTabelaCashback { get; set; }

        [Required]
        public decimal ValorPedido { get; set; }

        public virtual List<Pedido_ItemEntity> Itens { get; } = new List<Pedido_ItemEntity>();
        #endregion

        #region # Foreign Key
        [ForeignKey(nameof(IdCliente))]
        public ClienteEntity Cliente { get; set; }

        [ForeignKey(nameof(IdTabelaCashback))]
        public TabelaCashbackEntity TabelaCashback { get; set; }
        #endregion

        #region # Metodos
        public override bool IsValid()
        {
            if (Itens.Count == 0) return false;

            return true;
        }

        public void Finalizar()
        {
            this.Status = (byte) PedidoStatusEnum.Finalizado;
        }

        public void Cancelar()
        {
            this.Status = (byte)PedidoStatusEnum.Cancelado;
        }
        #endregion
    }
}
