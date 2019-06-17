using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VinilSales.Repository.Domain.CoreContext.Entities;

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

        public override void Validacao()
        {
            if (Itens.Count == 0) Mensagens.Add("A tabela de cashback não foi preenchida corretamente");
            if (DataInicioVigencia.Date < DateTime.Now.Date) Mensagens.Add("Não é permitido adicionar tabela de cashback com vigência retroativa");
        }
    }
}
