using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinilSales.Repository.Domain.CoreContext.Base;

namespace VinilSales.Repository.Domain.TabelaCashbackContext.Entities
{
    public class TabelaCashback_ItemEntity : BaseEntity
    {
        [Key]
        public int IdTabelaCashbackItem { get; set; }

        [Required]
        public int IdTabelaCashback { get; set; }

        [Required]
        [StringLength(50)]
        public byte Genero { get; set; }

        [Required]
        public decimal Domingo { get; set; }

        [Required]
        public decimal Segunda { get; set; }

        [Required]
        public decimal Terca { get; set; }

        [Required]
        public decimal Quarta { get; set; }

        [Required]
        public decimal Quinta { get; set; }

        [Required]
        public decimal Sexta { get; set; }

        [Required]
        public decimal Sabado { get; set; }

        #region # Foreign Key
        [ForeignKey("IdTabelaCashback")]
        public TabelaCashbackEntity TabelaCashback { get; set; }
        #endregion
    }
}
