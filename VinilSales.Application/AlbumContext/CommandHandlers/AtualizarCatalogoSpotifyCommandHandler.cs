using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using VinilSales.Application.AlbumContext.Commands;
using VinilSales.Application.AlbumContext.Results;
using VinilSales.Application.AlbumContext.Spotify;
using VinilSales.Application.CoreContext.Base;

namespace VinilSales.Application.AlbumContext.CommandHandlers
{
    public class AtualizarCatalogoSpotifyCommandHandler : BaseSimpleHandler, IRequestHandler<AtualizarCatalogoSpotifyCommand, bool>
    {
        public AtualizarCatalogoSpotifyCommandHandler(IMediator mediator) : base(mediator) { }

        public async Task<bool> Handle(AtualizarCatalogoSpotifyCommand request, CancellationToken cancellationToken)
        {
            var token = SpotifyLibrary.Instance.AccessToken;
            return true;
        }

        

        private async Task obterAlbuns(HttpClient client)
        {

        }
    }
}
