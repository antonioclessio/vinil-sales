using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VinilSales.Domain.CoreContext.ValueObjects;
using VinilSales.Repository.Domain.CoreContext.Base;

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
    }
}
