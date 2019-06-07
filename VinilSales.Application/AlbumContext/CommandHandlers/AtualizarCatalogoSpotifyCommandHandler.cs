using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VinilSales.Application.AlbumContext.Commands;
using VinilSales.Application.CoreContext.Base;

namespace VinilSales.Application.AlbumContext.CommandHandlers
{
    public class AtualizarCatalogoSpotifyCommandHandler : BaseHandler, IRequestHandler<AtualizarCatalogoSpotifyCommand, bool>
    {
        public AtualizarCatalogoSpotifyCommandHandler(IMediator mediator) : base(mediator) { }

        public Task<bool> Handle(AtualizarCatalogoSpotifyCommand request, CancellationToken cancellationToken)
        {
            using (var httpClient = createClient())
            {
                return null;
            }
        }

        private HttpClient createClient()
        {
            var client = new HttpClient();
            var clientID = "0bc559c060fe4eb2b0bc99e109528566";
            var clientSecret = "ced17a7405f9472f8ab4d663cb8bd479";

            client.BaseAddress = new Uri("https://accounts.spotify.com/api/token");

            var basicKey = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{clientID}:{clientSecret}"));
            var basicAuthHeader = new AuthenticationHeaderValue("Basic", basicKey);
            client.DefaultRequestHeaders.Authorization = basicAuthHeader;

            return client;
        }
    }
}
