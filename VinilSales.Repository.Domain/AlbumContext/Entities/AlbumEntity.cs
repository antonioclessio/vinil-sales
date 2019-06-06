using System.ComponentModel.DataAnnotations;
using VinilSales.Repository.Domain.CoreContext.Base;

namespace VinilSales.Repository.Domain.AlbumContext.Entities
{
    public class AlbumEntity : BaseEntity
    {
        [Key]
        public int IdAlbum { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }
    }
}
