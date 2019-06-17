using System.ComponentModel.DataAnnotations;
using VinilSales.Domain.CoreContext.ValueObjects;
using VinilSales.Repository.Domain.CoreContext.Entities;

namespace VinilSales.Repository.Domain.ClienteContext.Entities
{
    public class ClienteEntity : BaseEntity
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public CPF CPF { get; set; }

        public override void Validacao()
        {
            if (!CPF.Valido()) Mensagens.Add("O CPF informado é inválido");
        }
    }
}
