using System;
using System.Collections.Generic;
using System.Text;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Application.ProdutoContext.Results
{
    public class GetProdutosResult
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Artista { get; set; }
        public byte Genero { get; set; }

        public string GeneroDesricao
        {
            get
            {
                return Enum.GetName(typeof(GeneroEnum), Genero);
            }
        }
    }
}
