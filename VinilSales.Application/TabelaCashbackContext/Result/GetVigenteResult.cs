using System;
using System.Collections.Generic;
using System.Text;

namespace VinilSales.Application.TabelaCashbackContext.Result
{
    public class GetVigenteResult
    {
        public int IdTabelaCashback { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInicioVigencia { get; set; }

        public List<GetVigente_ItensResult> Itens { get; set; }
    }
}
