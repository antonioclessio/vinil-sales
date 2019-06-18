using System;
using System.Collections.Generic;

namespace VinilSales.Application.TabelaCashbackContext.Result
{
    public class ObterVigenteResult
    {
        public int IdTabelaCashback { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInicioVigencia { get; set; }

        public List<ObterVigente_ItensResult> Itens { get; set; } = new List<ObterVigente_ItensResult>();
    }
}
