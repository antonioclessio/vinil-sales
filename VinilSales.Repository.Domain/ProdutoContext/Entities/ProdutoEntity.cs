using System;
using System.ComponentModel.DataAnnotations;
using VinilSales.Domain.ProdutoContext.Enum;
using VinilSales.Repository.Domain.CoreContext.Entities;

namespace VinilSales.Repository.Domain.ProdutoContext.Entities
{
    public class ProdutoEntity : BaseEntity
    {
        [Key]
        public int IdProduto { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public byte Genero { get; set; }

        [Required]
        public string Artista { get; set; }

        public override void Validacao()
        {
            if (Preco == 0) Mensagens.Add("O preço do produto é inválido");
            if (!Enum.TryParse<GeneroEnum>(Genero.ToString(), out _)) Mensagens.Add("O gênero informado é inválido");
        }
    }
}
