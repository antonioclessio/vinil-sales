using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VinilSales.Application.ProdutoContext.Results;

namespace VinilSales.Application.ProdutoContext.Queries
{
    public class ObterProdutoQuery : IRequest<ObterProdutoResult>
    {
        public ObterProdutoQuery(int idProduto)
        {
            this.IdProduto = idProduto;
        }

        public int IdProduto { get; set; }
    }
}
