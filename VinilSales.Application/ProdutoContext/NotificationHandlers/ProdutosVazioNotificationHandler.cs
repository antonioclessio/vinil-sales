using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ProdutoContext.Notifications;
using VinilSales.Application.SpotifyContext;
using VinilSales.Domain.ProdutoContext.Enum;
using VinilSales.Repository.Domain.CoreContext.Base;
using VinilSales.Repository.Domain.ProdutoContext.Entities;
using VinilSales.Repository.Domain.ProdutoContext.Interfaces;

namespace VinilSales.Application.ProdutoContext.NotificationHandlers
{
    public class ProdutosVazioNotificationHandler : INotificationHandler<ProdutosVaziosNotification>
    {
        private IProdutoRepository _repository;

        public ProdutosVazioNotificationHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ProdutosVaziosNotification notification, CancellationToken cancellationToken)
        {
            var albuns = new Dictionary<GeneroEnum, SeedGenreResult>();
            albuns.Add(GeneroEnum.Classico, SpotifyFacade.Instance.ObterCatalogoClassic());
            albuns.Add(GeneroEnum.Pop, SpotifyFacade.Instance.ObterCatalogoPop());
            albuns.Add(GeneroEnum.MPB, SpotifyFacade.Instance.ObterCatalogoMPB());
            albuns.Add(GeneroEnum.Rock, SpotifyFacade.Instance.ObterCatalogoRock());

            var albunsEntity = new List<ProdutoEntity>();

            foreach (var album in albuns)
            {
                if (album.Value == null) continue;

                album.Value.Tracks.ForEach(track =>
                {
                    var novoAlbum = BaseEntity.Factory.CreateInstance<ProdutoEntity>();
                    novoAlbum.Nome = track.Album.Name;
                    novoAlbum.Preco = gerarPreco();
                    novoAlbum.Genero = (byte)album.Key;
                    novoAlbum.Artista = track.Album.Artists.First().Name;

                    albunsEntity.Add(novoAlbum);
                });
            }

            await _repository.AdicionarLista(albunsEntity);
        }
        private decimal gerarPreco()
        {
            var menorValor = 10.0M;
            var maiorValor = 80.0M;

            var random = new Random();
            var next = (decimal)random.NextDouble();

            return Math.Round(menorValor + (next * (maiorValor - menorValor)), 2);
        }

    }
}
