using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VinilSales.Application.AlbumContext.Commands;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.SpotifyContext;

namespace VinilSales.Application.AlbumContext.CommandHandlers
{
    public class AtualizarCatalogoSpotifyCommandHandler : BaseSimpleHandler, IRequestHandler<AtualizarCatalogoSpotifyCommand, bool>
    {
        public AtualizarCatalogoSpotifyCommandHandler(IMediator mediator) : base(mediator) { }

        public async Task<bool> Handle(AtualizarCatalogoSpotifyCommand request, CancellationToken cancellationToken)
        {
            var albunsRock = SpotifyLibrary.Instance.ObterCatalogoRock();
            return true;
        }
    }
}
