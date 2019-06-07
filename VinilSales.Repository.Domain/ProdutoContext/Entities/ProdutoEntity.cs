using System.ComponentModel.DataAnnotations;
using VinilSales.Repository.Domain.CoreContext.Base;

namespace VinilSales.Repository.Domain.ProdutoContext.Entities
{
    public class ProdutoEntity : BaseEntity
    {
        [Key]
        public int IdProduto { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }
}
