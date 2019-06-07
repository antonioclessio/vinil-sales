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
    public class AtualizarCatalogoSpotifyCommandHandler : BaseSimpleHandler, IRequestHandler<AtualizarCatalogoSpotifyCommand, bool>
    {
        public AtualizarCatalogoSpotifyCommandHandler(IMediator mediator) : base(mediator) { }

        public async Task<bool> Handle(AtualizarCatalogoSpotifyCommand request, CancellationToken cancellationToken)
        {
            using (var client = createClient())
            {
                await verificarAuthToken(client);
                await obterAlbuns(client);

                return true;
            }
        }

        private HttpClient createClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://accounts.spotify.com/api/");

            return client;
        }

        private async Task verificarAuthToken(HttpClient client)
        {
            var clientID = "0bc559c060fe4eb2b0bc99e109528566";
            var clientSecret = "ced17a7405f9472f8ab4d663cb8bd479";

            var basicKey = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{clientID}:{clientSecret}"));
            var basicAuthHeader = new AuthenticationHeaderValue("Basic", basicKey);
            client.DefaultRequestHeaders.Authorization = basicAuthHeader;

            var tokenResult = await client.PostAsync("token", null);
            if (tokenResult.IsSuccessStatusCode)
            {
                var token = tokenResult.Content.ReadAsStringAsync();
            }
        }

        private async Task obterAlbuns(HttpClient client)
        {

        }
    }
}
