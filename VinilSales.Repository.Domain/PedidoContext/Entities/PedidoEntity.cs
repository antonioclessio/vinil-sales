using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.CoreContext.Base;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;

namespace VinilSales.Repository.Domain.PedidoContext.Entities
{
    public class PedidoEntity : BaseEntity
    {
        [Key]
        public int IdPedido { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdTabelaCashback { get; set; }

        #region # Foreign Key
        [ForeignKey(nameof(IdCliente))]
        public ClienteEntity Cliente { get; set; }

        [ForeignKey(nameof(IdTabelaCashback))]
        public TabelaCashbackEntity TabelaCashback { get; set; }
        #endregion
    }
}
