using MediatR;
using System.Collections.Generic;
using VinilSales.Application.ProdutoContext.Results;

namespace VinilSales.Application.ProdutoContext.Queries
{
    public class GetProdutosQuery : IRequest<IEnumerable<GetProdutosResult>>
    {
    }
}
