using MediatR;
using System.Collections.Generic;
using VinilSales.Application.AlbumContext.Results;

namespace VinilSales.Application.AlbumContext.Queries
{
    public class GetAlbunsQuery : IRequest<IEnumerable<GetAlbunsResult>>
    {
        public GetAlbunsQuery()
        {

        }
    }
}
