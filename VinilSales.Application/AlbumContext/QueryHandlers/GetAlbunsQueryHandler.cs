using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.AlbumContext.Commands;
using VinilSales.Application.AlbumContext.Queries;
using VinilSales.Application.AlbumContext.Results;
using VinilSales.Application.CoreContext.Base;

namespace VinilSales.Application.AlbumContext.QueryHandlers
{
    public class GetAlbunsQueryHandler : BaseSimpleHandler, IRequestHandler<GetAlbunsQuery, IEnumerable<GetAlbunsResult>>
    {
        public GetAlbunsQueryHandler(IMediator mediator) : base(mediator) {}

        public Task<IEnumerable<GetAlbunsResult>> Handle(GetAlbunsQuery request, CancellationToken cancellationToken)
        {
            _mediator.Send(new AtualizarCatalogoSpotifyCommand());
            return null;
        }
    }
}
