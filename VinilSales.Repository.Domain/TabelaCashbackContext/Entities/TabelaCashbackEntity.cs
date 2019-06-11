using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VinilSales.Repository.Domain.CoreContext.Base;

namespace VinilSales.Repository.Domain.TabelaCashbackContext.Entities
{
    public class TabelaCashbackEntity : BaseEntity
    {
        [Key]
        public int IdTabelaCashback { get; set; }

        [Required]
        public DateTime DataInicioVigencia { get; set; }

        [StringLength(300)]
        public string Observacao { get; set; }

        public virtual List<TabelaCashback_ItemEntity> Itens { get; } = new List<TabelaCashback_ItemEntity>();
    }
}
