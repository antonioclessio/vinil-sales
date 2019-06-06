using System.ComponentModel.DataAnnotations;
using Vinil.Repository.Domain.CoreContext.Base;

namespace Vinil.Repository.Domain.AlbumContext.Entities
{
    public class AlbumEntity : BaseEntity
    {
        [Key]
        public int IdAlbum { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }
    }
}
