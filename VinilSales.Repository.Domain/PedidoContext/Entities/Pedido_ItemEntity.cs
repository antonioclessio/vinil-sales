﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VinilSales.Repository.Domain.PedidoContext.Entities
{
    public class Pedido_ItemEntity
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
        public bool IsValid()
        {
            if (Quantidade == 0 || IdPedido == 0 || IdProduto == 0)
                return false;

            return true;
        }
        #endregion
    }
}
