using MediatR;
using System.Collections.Generic;
using VinilSales.Application.ClienteContext.Results;

namespace VinilSales.Application.ClienteContext.Queries
{
    public class GetClientesQuery : IRequest<IEnumerable<GetClientesResult>>
    {
    }
}
