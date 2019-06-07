using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VinilSales.Application.AlbumContext.Events;

namespace VinilSales.Application.AlbumContext.EventHandlers
{
    public class AtualizarCatalogoSpotifyEventHandler : INotificationHandler<AtualizarCatalogoSpotifyEvent>
    {
        public Task Handle(AtualizarCatalogoSpotifyEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
