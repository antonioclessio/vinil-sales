using System.Threading.Tasks;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;

namespace VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces
{
    public interface ITabelaCashbackRepository
    {
        Task<TabelaCashbackEntity> ObterTabelaVigente();
    }
}
