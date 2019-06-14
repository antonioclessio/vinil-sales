using MediatR;
using System.Collections.Generic;
using VinilSales.Application.ProdutoContext.Results;
using VinilSales.Domain.ProdutoContext.Model;

namespace VinilSales.Application.ProdutoContext.Queries
{
    public class ObterProdutosQuery : IRequest<IEnumerable<ObterProdutosResult>>
    {
        public ObterProdutosQuery(ProdutoFiltroModel filtro)
        {
            this.Filtro = filtro;
        }

        public ProdutoFiltroModel Filtro { get; set; }
    }
}
